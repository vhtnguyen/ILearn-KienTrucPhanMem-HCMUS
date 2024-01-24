using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 Một công ty có cấu hình máy tính đều giống nhau cho tất cả nhân viên, bao gồm: Hệ điều hành (os), Phần mềm văn phòng (office), Phần mềm diệt virus (antivirus), Trình duyệt (Browser), và một số phần mềm khác (others) tùy theo nhu cầu của mỗi nhân viên sẽ được cài đặt thêm. Việc cài đặt tất cả phần mềm trên rất tốn thời gian, nên anh IT đã nghĩ ra một cách là sẽ tạo ra một bản chuẩn cho một máy tính và có thể clone() lại cấu hình đó cho một nhân viên khác mà không cần phải cài đặt lại từ đầu.
 */

namespace creationalPrototype.Laptop
{
    class Program
    {
        static void Main(string[] args)
        {
            Laptop laptop_master = new Laptop("Window 10", "Word 2013", "BKAV", "Chrome v69", "Skype");
            Laptop laptop_staff = (Laptop)laptop_master.Clone();
            laptop_staff.SetOthers("Skype, Teamviewer, FileZilla Client");
            Console.WriteLine(laptop_master.ToString());
            Console.WriteLine(laptop_staff.ToString());
        }
    }
}
