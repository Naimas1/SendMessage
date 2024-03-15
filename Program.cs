using System.Runtime.InteropServices;

namespace SendMessage
{
    internal class Program
    {
        // Импорт функции FindWindow из библиотеки user32.dll
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Импорт функции SendMessage из библиотеки user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, string lParam);

        static void Main()
        {
            // Поиск окна по его заголовку
            IntPtr windowHandle = FindWindow(null, "Название вашего окна");

            // Проверка на наличие окна
            if (windowHandle != IntPtr.Zero)
            {
                // Отправка сообщения об изменении заголовка окна
                SendMessage(windowHandle, WM_SETTEXT, 0, "Новый заголовок");

                // SendMessage(windowHandle, MY_CUSTOM_MESSAGE, 0, "Пользовательское сообщение");
            }
            else
            {
                object value = MessageBox.Show("Окно не найдено.");
            }
        }

        // Константы для отправки сообщения
        const uint WM_SETTEXT = 0x000C;
        const uint MY_CUSTOM_MESSAGE = 0x1000; // Пример пользовательского сообщения
        private static object MessageBox;
    }
}