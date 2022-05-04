WinWait("Open", "", 10)
ControlFocus("Open","","Edit1")
Sleep(750)
ControlSetText("Open", "", "Edit1", "G:\onboarding.nunit\MarsFramework\AutoIT\Fileupload\worksample.txt")
Sleep(750)
ControlClick("Open", "", "Button1");