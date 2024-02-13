using System;
using System.Runtime.InteropServices;

[DllImport("user32.dll", CharSet = CharSet.Unicode, EntryPoint ="MessageBox")]
static extern int MyNewMassageBoxMethod(IntPtr hwnd, String text, String caption, uint type);  

int button = MyNewMassageBoxMethod(new IntPtr(0), "Hello World", "Hallo Dialog", 1);

Console.WriteLine(button);

int button1 = MyNewMassageBoxMethod(new IntPtr(0), "Hello World", "Hallo Dialog", 2);

Console.WriteLine(button1);

int button2 = MyNewMassageBoxMethod(new IntPtr(0), "Hello World", "Hallo Dialog", 3);

Console.WriteLine(button2);

