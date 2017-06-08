# -*- coding:utf-8 -*-
import difflib
import sys
import os

def test():
	a='在VRay 的安装目录下面的bin目录下运行“vrayrtspawner.exe”程序即可接受其他主机的渲染请求。运行改程序后提示在20206端口监听接受请求。该方式会一直监控渲染服务状态如果服务被关闭就尝试新打开一个服务。'
	b='在VRay bin目录下运行的安装目录下面的“vrayrtspawner.exe”程序即可接受其他主机的渲染请求。程序后提示在20206端运行改口监听接受请求。该方式会一直监控渲染服务状态如果服务被关闭就尝试新打开一个服务。'
	ratio=difflib.SequenceMatcher(None,a,b).ratio()
	print(ratio)

def printfile(f):
	mfile=open(f,encoding= 'utf-8')
	print(mfile.read())

def deserlize(f):
	mfile=open(f,encoding= 'utf-8')

	keycontent={}
	stat=0
	key=''
	content=''
	while 1:
		line=mfile.readline()
		if not line :
			break
		line=line.strip()

	 
		if line == 'KEY:':
			if stat==2:
				keycontent[key]=content

			key=line=mfile.readline()
			stat=1
		
		if stat==2:
			content=content+line
		if line =='CNT:':
			stat=2
	keycontent[key]=content
	#print(keycontent)
	return keycontent

def comparefile(filename,dicts,resultfile):
	selfdict=dicts[filename]
	content=''
	content1=''
	filedict={}

	resultfile.write('FILE:\n');
	resultfile.write(filename+'\n');
	print('Python->File:'+filename)

	fratio2=0
	for key in selfdict:
		resultfile.write("  KEY:\n")
		resultfile.write("  "+key.strip()+'\n')
		content=selfdict[key]
		print('Python->Key:' + str(key))
		resultfile.write("    RATIO:\n")
		if content =='':
			continue
		for filekey in dicts:
			if filekey != filename:
				
				filedict=dicts[filekey]
				if key in filedict:
					content1=filedict[key]
				else:
					continue

				if content1 =='':
					resultfile.write("    "+filekey+":内容为空\n");
					continue
				#calculate match ratio
				#print(content+'->'+content1)
				ratio=difflib.SequenceMatcher(None,content,content1).ratio()
				ratio=round(ratio*100,2)
				resultfile.write("    "+filekey+":"+str(ratio)+'%\n');
				print('Python->CompareWith:'+filekey)
				print('             Smilar:'+str(ratio))

def rundiff(wpath,outfile):

	resultpath=wpath+'\\RESULT\\'
	if not os.path.exists(resultpath):
		os.mkdir(resultpath)

	files=os.listdir(wpath)
	index=0
	dicts={}
	for f in files:
		if os.path.isfile(wpath+f): 
			dicts[f]=deserlize(wpath+f)


	resultfile=open(outfile,'w+')
	for f in dicts:
		comparefile(f,dicts,resultfile)

	resultfile.close()
	#print(outfile)

	 




if len(sys.argv) > 1:
	rundiff(sys.argv[1],sys.argv[2])
else:
	print("请设置工作路径")

#test()