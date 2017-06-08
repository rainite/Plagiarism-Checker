using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Words;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Collections;
using Microsoft.Win32;
using System.Configuration;
using System.Configuration.Assemblies;
using System.Configuration.Internal;

namespace DOCXM
{
    public partial class DOCXM : Form
    {
        Process myProcess = null;
        List<string> file_paths=null;
        List<KeyPairBean> KeyPairs = new List<KeyPairBean>();
        String WorkPath = null;
        String PythonPath = "";
        String PythonFile = "";
        Hashtable SimilarResult = null;
        String SelectFile;
        String SelectKey;

        delegate void PyMessage(String msg);
        PyMessage pyMessage = null;
        delegate void ThreadProgress(int progress,int total);
        ThreadProgress threadProgress = null;
        delegate void SetSimilarResult(Hashtable hashtale);
        SetSimilarResult setSimilarResult = null;


        DealProgress progress = null;


        public String getSelectMainFile()
        {
            if (lv_words.Items.Count <= 0)
                return null;

            if(lv_words.SelectedItems.Count>0)
            {
                return lv_words.SelectedItems[0].Text.Replace(".doc",".txt");
            }
            else
            {
                return lv_words.Items[0].Text.Replace(".doc", ".txt");
            }
        }
        public String getSelectKey()
        {
            if (lv_keypair.Items.Count <= 0)
                return null;

            if(lv_keypair.SelectedItems.Count>0)
            {
                ListViewItem item = lv_keypair.SelectedItems[0];
                return item.Text + "," + item.SubItems[1].Text + "," + item.SubItems[2].Text;
            }
            else
            {
                ListViewItem item = lv_keypair.Items[0];
                return item.Text + "," + item.SubItems[1].Text + "," + item.SubItems[2].Text;
            }
        }

        private void freshResult()
        {
            if (SimilarResult == null)
                return;

            if (SelectKey == null || SelectFile == null)
                return;

            Hashtable t = SimilarResult[SelectFile] as Hashtable;

            if (t == null)
                return;

            t = t[SelectKey] as Hashtable;

            lv_doc_same.Items.Clear();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem subitem = null;
            foreach (String key in t.Keys)
            {
                item = new ListViewItem();
                item.Text = key;
                subitem = new ListViewItem.ListViewSubItem();
                subitem.Text = t[key].ToString();

                item.SubItems.Add(subitem);

                lv_doc_same.Items.Add(item);
            }
            lv_doc_same.Sorting = SortOrder.Ascending;
            lv_doc_same.Sort();


            lb_keypair.Text ="FILE:"+ SelectFile + "  KEY:"+SelectKey;

            String str = readCNTWithKey(WorkPath + "\\ATXT\\" + SelectFile, SelectKey);
            tb_content.Text = str;

        }
        public void fsetSimilarResult(Hashtable result)
        {
            if (result == null)
                return;
            this.SimilarResult = result;
            String mainFile = getSelectMainFile();
            String seleKey = getSelectKey();

            SelectKey = seleKey;
            SelectFile = mainFile;
            freshResult();
        }
        public void setThreadProgress(int p,int t)
        {

            if (progress == null)
                return;

            //if (p == 0)
            //{
            //    progress.setMax(t);
            //}
            //else
                
            if(p==t)
            {
                progress.Close();
            }
            else
            {
                progress.setProgress(p,t);
            }
        }

        public DOCXM()
        {
            InitializeComponent();
            
        }
        


        
        private void Form1_Load(object sender, EventArgs e)
        {

            

            int width = lv_keypair.Width / 3;
            lv_keypair.Columns.Add("Name", width); 
            lv_keypair.Columns.Add("Start", width);
            lv_keypair.Columns.Add("End", width);

            lv_words.Columns.Add("Word Documents List",lv_words.Width);

            lv_doc_same.Columns.Add("Documents", lv_words.Width);
            lv_doc_same.Columns.Add("Similar", lv_words.Width);

            pyMessage = fpyMessage;
            threadProgress = setThreadProgress;
            setSimilarResult = fsetSimilarResult;

            //读取基本配置文件
            if(File.Exists("config.txt"))
            {
                FileStream file = new FileStream("config.txt", FileMode.Open);
                StreamReader reader = new StreamReader(file);
                
                PythonFile = reader.ReadLine();
                if(!File.Exists(PythonFile))
                {
                    PythonFile = "differnt.py";
                }else 
                {
                    int index = PythonFile.IndexOf(".py");
                    if(index<=0)
                    {
                        PythonFile = "differnt.py";
                    }else{
                             if ( index != PythonFile.Length - 3)
                             {
                                 PythonFile = "differnt.py";
                             }
                    }
                       
                }
                reader.Close();
                file.Close();
            }
            else
            {
                PythonFile = "different.py";
            }


            FileStream pyFile = new FileStream("py.config",FileMode.OpenOrCreate);
            StreamReader pyReader=new StreamReader(pyFile);
            PythonPath = pyReader.ReadLine();
            if(PythonPath==null||PythonPath==""||!File.Exists(PythonPath))
            {
                try
                {
                    PythonPath = getPythonPath(RegistryView.Registry64) + "python.exe";
                }
                catch
                {
                    try
                    {
                        PythonPath = getPythonPath(RegistryView.Registry32) + "python.exe";
                    }
                    catch
                    {



                        MessageBox.Show("没有找到python安装路径,手动选择");
                        OpenFileDialog dlg = new OpenFileDialog();
                        dlg.Filter = "Python.exe|python.exe";
                        while (true)
                        {
                            if (dlg.FileName == "")
                                dlg.ShowDialog();
                            else
                                break;
                        }
                        PythonPath = dlg.FileName;
                         
                    }
                }
                pyReader.Close();
                pyFile.Close();
               

                pyFile = new FileStream("py.config", FileMode.Create);
                StreamWriter writer = new StreamWriter(pyFile);
                writer.WriteLine(PythonPath);
                
                writer.Close();
                pyFile.Close();
                
            }
            
           
            
        }


        DealProgress pythonProgress = null;
        private void btnExcutePy_Click(object sender, EventArgs e)
        {

            DealProgress progress = new DealProgress();
            pythonProgress = progress;
            Thread thread = new Thread(threadCallPython);
            thread.Start();
            progress.ShowDialog();
            
        }

        public void threadCallPython()
        {
            myProcess = new Process();
            //process.e
            if (WorkPath == "" || WorkPath == null)
            {
                MessageBox.Show("请先选择文档路径");
                return;
            }
            //System.Security.AccessControl.DirectorySecurity sercruty = new System.Security.AccessControl.DirectorySecurity();


            Directory.CreateDirectory(WorkPath + "\\ATXT\\RESULT");


            String argv = WorkPath + "\\ATXT\\";
            argv += " " + argv + "RESULT\\result.txt";

            if(!File.Exists(PythonFile))
            {
                PythonFile = "different.py";
            }

            argv = PythonFile + "  " + argv;
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(PythonPath, argv);
            myProcessStartInfo.CreateNoWindow = true;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.UseShellExecute = false;

            myProcess.StartInfo = myProcessStartInfo;
            //myProcess.UseShellExecute = false;
            myProcess.Start();
            StreamReader output = myProcess.StandardOutput;

            String outMsg = null;
            object[] msgs = new object[1];

            pythonProgress.setProgress(50,100);
            int count = 100;
            while (true)
            {
                outMsg = output.ReadLine();
                if (outMsg == null)
                {
                    count--;
                    
                    if(count==0)
                        break;
                    else
                        continue;
                }
                count = 100;
                if(outMsg!=null)
                {
                    msgs[0] = outMsg;
                    this.Invoke(pyMessage, msgs);
                }

            }
            output.Close();
            //MessageBox.Show("Exe Colosed");
            myProcess.WaitForExit();
            if (!myProcess.HasExited)
                myProcess.Kill();
            deserilize();
            pythonProgress.setProgress(100, 100);
            pythonProgress.Close();
            pythonProgress = null;
        }

        public void fpyMessage(String msg)
        {
            lbPyOut.Items.Add(msg);
            lbPyOut.TopIndex = lbPyOut.Items.Count - (int)(lbPyOut.Height / lbPyOut.ItemHeight);
        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            KEYPair dlg = new KEYPair();
            dlg.ShowDialog();
            if(dlg.HaveValidValue)
            {
                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem subitem = new ListViewItem.ListViewSubItem();
                ListViewItem.ListViewSubItem subitem1 = new ListViewItem.ListViewSubItem();

                item.Text = dlg.PairName;
                
                subitem.Text = dlg.Start;
                subitem1.Text = dlg.End;

                item.SubItems.Add(subitem);
                item.SubItems.Add(subitem1);
                lv_keypair.Items.Add(item);
                //lv_keypair.Items
            }

        }

        private void btnDelKey_Click(object sender, EventArgs e)
        {
            if(lv_keypair.SelectedItems.Count>0)
            lv_keypair.SelectedItems[0].Remove();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            String path = dlg.SelectedPath;

            if (path == ""||path==null)
                return;
            DirectoryInfo dir = new DirectoryInfo(path);

            List<String> files = new List<string>();
            List<String> file_paths = new List<string>();

            SubFind sub_find = new SubFind();
            sub_find.ShowDialog();



            docFiles(file_paths, files, dir, sub_find.Level);

            files.Sort();
            file_paths.Sort();

            this.file_paths = file_paths;


            lv_words.Items.Clear();
            ListViewItem item = new ListViewItem();
            foreach(String f in files)
            {
                item = new ListViewItem();
                item.Text = f;
                lv_words.Items.Add(item);
            }
            WorkPath = path;
        }
        public void docFiles(List<String> file_paths, List<String> files, DirectoryInfo dir, int level)
        {
            if(level>=1)
                foreach(DirectoryInfo subdir in dir.GetDirectories())
                {
                    docFiles(file_paths,files, subdir, level - 1);
                }

            foreach(FileInfo file in dir.GetFiles("*.doc"))
            {
                if(file.Extension==".doc"&&file.Name.IndexOf("~")<0)
                {
                    file_paths.Add(file.FullName);
                    files.Add(file.Name);
                }
            }
        }

        private void btn_2Txt_Click(object sender, EventArgs e)
        {
         
            Directory.CreateDirectory(WorkPath + "\\ATXT\\");

            if (lv_words.Items.Count <= 0)
            {
                MessageBox.Show("请先打开文档文件夹");
                return;
            }
            
            if(lv_keypair.Items.Count<=0)
            {
                MessageBox.Show("请先输入关键词组");
                return;
            }
            KeyPairs.Clear();
            KeyPairBean bean = null;
            foreach (ListViewItem item in lv_keypair.Items)
            {

                bean = new KeyPairBean();
                bean.Name = item.Text;
                bean.Start = item.SubItems[1].Text;
                bean.End = item.SubItems[2].Text;
                KeyPairs.Add(bean);
            }

            progress = new DealProgress();
            Thread thread = new Thread(threadDeal);
            thread.Start();
            progress.ShowDialog();
        }

        public String getFileSortName(String file)
        {
            int i=file.LastIndexOf("\\");
            int j = file.LastIndexOf(".doc");
            return file.Substring(i, j - i);
        }
        public void threadDeal()
        {
            String key_name = "";
            String key_start = "";
            String key_end = "";
            int total = file_paths.Count;
            int index = 0;
            object[] paras=new object[2];
            foreach (String file in file_paths)
            {
                String content = "";
                Document doc = new Document(file);
                String doc_content = doc.GetText();

                String sortName = getFileSortName(file);
                foreach (KeyPairBean keypair in KeyPairs)
                {
                    key_name = keypair.Name;
                    key_start = keypair.Start;
                    key_end = keypair.End;
                    content += "KEY:\n"+key_name + "," + key_start + "," + key_end + "\n";

                    content += "CNT:\n" + getDocTxt(doc_content, key_name, key_start, key_end);

                    //fpyMessage(key_name + ": " + key_start + "," + key_end);
                    this.Invoke(pyMessage, new object []{sortName+"->"+ key_name + ": " + key_start + "," + key_end });
                }
                saveString2File(WorkPath + "\\ATXT\\" + sortName + ".txt", content);

                index++;
                paras[0] = index;
                paras[1] = total;
                this.Invoke(threadProgress, paras);

                
            }
        }
        public String getDocTxt(String  str,String keyName,String keyStart,String keyEnd)
        {
            

            int i1 = str.IndexOf(keyStart) + keyStart.Length;
            int i2 = str.IndexOf(keyEnd);

            if(i1<0)
            {
                return "";
            }
            if (i2 < i1)
            {
                return "";
            }
            str = str.Substring(i1, i2 - i1);
            return str+"\n";
        }
        public void saveString2File(String filename,String content)
        {
            FileStream file = new FileStream(filename, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);
            writer.Write(content);
            writer.Close();
            file.Close();
        }

        private void btnReadKeyFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "KeyPair|*.Key";
            dlg.ShowDialog();
            if (dlg.FileName == "")
                return;

            FileStream file = new FileStream(dlg.FileName,FileMode.Open);
            StreamReader reader = new StreamReader(file);
            String line = null;
            String[] key = null;


            ListViewItem item = null;
            ListViewItem.ListViewSubItem subitem = null;
            ListViewItem.ListViewSubItem subitem1 = null;



            while(true)
            {
                line = reader.ReadLine();
                if(line!=null)
                {
                    key=line.Split(',');

                    item = new ListViewItem();
                    subitem = new ListViewItem.ListViewSubItem();
                    subitem1 = new ListViewItem.ListViewSubItem();

                    item.Text = key[0];
                    subitem.Text = key[1];
                    subitem1.Text = key[2];

                    item.SubItems.Add(subitem);
                    item.SubItems.Add(subitem1);
                    lv_keypair.Items.Add(item);
                }
                else
                {
                    break;
                }
            }
            reader.Close();
            file.Close();
        }

        private void btnSaveKey_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "KeyPair|*.Key";
            dlg.ShowDialog();
            if(dlg.FileName=="")
            {
                return;
            }
            
            FileStream file = new FileStream(dlg.FileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(file);

            String line = "";
            foreach(ListViewItem item in lv_keypair.Items)
            {
                line = item.Text + "," + item.SubItems[1].Text +","+ item.SubItems[2].Text;
                writer.WriteLine(line);
            }
            writer.Close();
            file.Close();

            
        }

        public void deserilize()
        {
            String filename = WorkPath + "\\ATXT\\RESULT\\result.txt";
            FileStream file = new FileStream(filename,FileMode.Open);
            StreamReader reader = new StreamReader(file, Encoding.GetEncoding("GB2312"));

            String FILE = "FILE:";
            String KEY = "KEY:";
            String RATIO = "RATIO:";

           
          


            Hashtable FileSimilarHash = new Hashtable();
            Hashtable KeySimilarHash = null;
            Hashtable FileRatioHash = null;
            //SimilarPart similarPart = null;

            String line = null;
            Boolean readline = true;
            while(true)
            {
                if(readline)
                    line = reader.ReadLine();
                readline = true;
                if (line == null)
                    break;

                line = line.Trim();
                if(line==FILE)
                {
                    line = reader.ReadLine();
                    line = line.Trim();
                    KeySimilarHash = new Hashtable();
                    FileSimilarHash.Add(line, KeySimilarHash);

                    #region 读取关键字下面的相似度
                    while (true)
                    {
                        if (readline)
                        {
                            line = reader.ReadLine();
                            line = line.Trim();
                        }
                        if (line == FILE || line == null)
                        {
                            readline = false;
                            break;
                        }
                        readline = true;

                        if (line == KEY)
                        {
                            if(readline)
                                line = reader.ReadLine();

                            if (line == null)
                            {
                                readline = false;
                                break;
                            }
                            line = line.Trim();
                            //MessageBox.Show(line);
                            FileRatioHash = new Hashtable();
                            KeySimilarHash.Add(line, FileRatioHash);

                            line = reader.ReadLine();

                            line = line.Trim();
                            if (line == RATIO)
                            {
                                #region 读取每个关键字下面对每个文件的相似度

                                while (true)
                                {
                                    line = reader.ReadLine();
                                    if (line == null)
                                    {
                                        readline = false;
                                        break;
                                    }   
                                    line = line.Trim();
                                    if (line == FILE)
                                    {
                                        readline = false;
                                        break;
                                    }
                                    else if (line == KEY || line == null)
                                    {
                                        readline = false;
                                        break;
                                    }
                                    else
                                    {
                                        String[] fresult = line.Split(':');
                                        if(fresult.Length>=2)
                                            FileRatioHash.Add(fresult[0], fresult[1]);
                                    }
                                }
                                #endregion
                            }
                        }
                        //if (readline == false)
                        //    break;
                    }
                    #endregion

                }
            }
            reader.Close();
            file.Close();
            if(setSimilarResult!=null)
            {
                object[] para = new object[1];
                para[0] = FileSimilarHash;
                this.Invoke(setSimilarResult, para);
            }
                
        }

        private void lv_words_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectFile = getSelectMainFile();
            freshResult();
        }

        private void lv_keypair_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectKey = getSelectKey();
            freshResult();

            String str = readCNTWithKey(WorkPath + "\\ATXT\\" + SelectFile, SelectKey);
            tb_content.Text = str;
        }

        private String readCNTWithKey(String filename,String key)
        {
            FileStream file = new FileStream(filename, FileMode.Open);
            StreamReader reader = new StreamReader(file);

            String line = null;
            String content = "";
            while(true)
            {
                line = reader.ReadLine();
                if (line == null)
                    break;

                line=line.Trim();
                #region 识别关键字
                if (line=="KEY:")
                {
                    line=reader.ReadLine();
                    if(line==null)
                        continue;
                    line=line.Trim();
                    if(line==key)
                    {
                        line = reader.ReadLine();
                        if (line != null && line.Trim() == "CNT:")
                        #region 识别数据
                        while (true)
                        {
                            line=reader.ReadLine();
                            if (line==null)
                            {
                                break;
                            }
                            
                                if(line.Trim()=="KEY:")
                                {
                                    break;
                                }
                                content+=line+"\n";
                           
                        }
                        #endregion
                        break;
                    }
                }
                #endregion
            }

            reader.Close();
            file.Close();
            if (content == ""||content==null)
            {

                return "无内容";
            }
               
            return content;
        }

        private void lv_words_DoubleClick(object sender, EventArgs e)
        {
            String str=readCNTWithKey(WorkPath+"\\ATXT\\"+ SelectFile, SelectKey);
            tb_content.Text = str;
        }

        private String getPythonPath( RegistryView regv)
        {

            //String str= Environment.GetEnvironmentVariable("Path");
            //String []paths = str.Split(';');

            //foreach(String py in paths)
            //{
            //    if(py.Contains("Python"))
            //    {
            //        MessageBox.Show(py);
            //    }
            //}
            
            String[] keys = "SOFTWARE\\Wow6432Node\\Python\\PythonCore".Split('\\');

           
            RegistryKey reg= RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            //RegistryKey reg = Registry.LocalMachine;
            RegistryKey tk = null;

            //依次按照 路径节点，找到python的安装信息，下面可能有多个版本，使用找到的第一个版本
            foreach (String k in keys)
            {
                tk = reg.OpenSubKey(k);

                if (tk == null)
                {
                    break;
                }
                else
                {
                    reg = tk;
                }
            }

            String[] values = reg.GetSubKeyNames();

            //使用找到的第一个版本,
            reg = reg.OpenSubKey(values[0]).OpenSubKey("InstallPath");
            object v = reg.GetValue("");//默认安装路径，注册表键值名称为空字符串。
            return v.ToString();
        }
    }
}
