image-separator.exe: image-separator.cs
	csc image-separator.cs /r:System.Windows.Forms.dll /r:System.Drawing.dll

clean:
	rm -vf image-separator.exe

run: image-separator.exe
	chmod +x image-separator.exe
	./image-separator.exe farabank.png 10
