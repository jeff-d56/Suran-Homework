Ubuntu takes the directory of the select folder in the console so the Sort Me.txt should just be in the same place as the program.exe
I used Mono to compile and run the C# file in Ubuntu
 
I Installed Mono by typeing this into the Ubuntu console.

sudo apt install apt-transport-https dirmngr
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb https://download.mono-project.com/repo/ubuntu vs-bionic main" | sudo tee /etc/apt/sources.list.d/mono-official-vs.list
sudo apt update
sudo apt install mono-complete


Make sure the directory in the Ubuntu consle is set to the Ubuntu folder.
For example my directiery was.

cd /mnt/c/Desktop/Program/Ubuntu

I placed my file on the desktop in windows so just set this to where ever you directory for the Program.exe file is.

The Program should alrady be compiled but if it needs to be recompiled you can use
mcs -out:Program.exe Program.cs

Then to run the program type
mono Program.exe

