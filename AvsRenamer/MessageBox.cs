using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AvsRenamer
{
    public static class MessageBox
    {
        internal class NativeMethods
        {
            [DllImport("User32.dll")]
            public static extern int MessageBox(IntPtr h, string message, string caption, uint type);
        }

        // Methods
        public static MessageBoxResult Show(string message)
        {
            return Show(message, string.Empty);
        }

        public static MessageBoxResult Show(string message, string caption)
        {
            return Show(message, caption, MessageBoxButtons.MB_OK);
        }

        public static MessageBoxResult Show(string message, string caption, MessageBoxButtons options)
        {
            return Show(message, caption, options, MessageBoxIcon.None);
        }

        public static MessageBoxResult Show(string message, string caption, MessageBoxButtons options, MessageBoxIcon icon)
        {
            return Show(message, caption, options, icon, MessageBoxDefaultButton.MB_DEFBUTTON1);
        }

        public static MessageBoxResult Show(string message, string caption, MessageBoxButtons options, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton)
        {
            return Show(message, caption, options, icon, defaultButton, MessageBoxModality.MB_APPLMODAL);
        }

        public static MessageBoxResult Show(string message, string caption, MessageBoxButtons options, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxModality modality)
        {
            return Show(message, caption, options, icon, defaultButton, modality, MessageBoxOptions.None);
        }

        public static MessageBoxResult Show(string message, string caption, MessageBoxButtons options, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxModality modality, MessageBoxOptions otherOptions)
        {
            return (MessageBoxResult)NativeMethods.MessageBox(Process.GetCurrentProcess().MainWindowHandle, message, caption, (uint)options + (uint)icon + (uint)defaultButton + (uint)modality + (uint)otherOptions);
        }
    }

    // Defined Types
    public enum MessageBoxResult
    {
        // MessageBox Notification Result Constants
        ID_ABORT = 0x3,
        ID_CANCEL = 0x2,
        ID_CONTINUE = 0xB,
        ID_IGNORE = 0x5,
        ID_NO = 0x7,
        ID_OK = 0x1,
        ID_RETRY = 0x4,
        ID_TRYAGAIN = 0xA,
        ID_YES = 0x6
    }

    public enum MessageBoxButtons : uint
    {
        // Buttons
        MB_ABORTRETRYIGNORE = 0x2,
        MB_CANCELTRYCONTINUE = 0x6,
        MB_HELP = 0x4000,
        MB_OK = 0x0,
        MB_OKCANCEL = 0x1,
        MB_RETRYCANCEL = 0x5,
        MB_YESNO = 0x4,
        MB_YESNOCANCEL = 0x3,
    }

    public enum MessageBoxIcon : uint
    {
        // Icons
        None = 0x0,
        MB_ICONEXCLAMATION = 0x30,
        MB_ICONWARNING = 0x30,
        MB_ICONINFORMATION = 0x40,
        MB_ICONASTERISK = 0x40,
        MB_ICONQUESTION = 0x20,
        MB_ICONSTOP = 0x10,
        MB_ICONERROR = 0x10,
        MB_ICONHAND = 0x10,
    }

    public enum MessageBoxDefaultButton : uint
    {
        // Default Buttons
        MB_DEFBUTTON1 = 0x0,
        MB_DEFBUTTON2 = 0x100,
        MB_DEFBUTTON3 = 0x200,
        MB_DEFBUTTON4 = 0x300,
    }

    public enum MessageBoxModality : uint
    {
        // Modality
        MB_APPLMODAL = 0x0,
        MB_SYSTEMMODAL = 0x1000,
        MB_TASKMODAL = 0x2000,
    }

    public enum MessageBoxOptions : uint
    {
        // Other Options
        None = 0x0,
        MB_DEFAULT_DESKTOP_ONLY = 0x20000,
        MB_RIGHT = 0x80000,
        MB_RTLREADING = 0x100000,
        MB_SETFOREGROUND = 0x10000,
        MB_TOPMOST = 0x40000,
        MB_SERVICE_NOTIFICATION = 0x200000
    }
}
