using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

struct ToaDo
{
    public int toado_dong, toado_cot;
};

namespace Version_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // vitridong: Là vị trí dòng của quân vừa đánh xuống
        // vitricot: Là vị trí cột của quân vừa đánh xuống
        bool KiemTraHangNgang(Button[,] a, int socot, int vitridong, int vitricot)
        {
	        int dem = 1; // Tính luôn quân vừa đánh xuống

	        // Xét qua bên trái trước (ngang trái)
	        for(int j = vitricot - 1; j >= 0; --j)
	        {
		        if(a[vitridong, j].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        
				        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }
	        }

	        // Xét qua bên phải (ngang phải)
	        for(int j = vitricot + 1; j < socot; ++j)
	        {
                if (a[vitridong, j].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        
				        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }
	        }
	        return false; // chưa thắng
        }

        // vitridong: Là vị trí dòng của quân vừa đánh xuống
        // vitricot: Là vị trí cột của quân vừa đánh xuống
        bool KiemTraHangDoc(Button[,] a, int sodong, int vitridong, int vitricot)
        {
	        int dem = 1; // Tính luôn quân vừa đánh xuống

	        // Xét lên trên trước (dọc trên)
	        for(int i = vitridong - 1; i >= 0; --i)
	        {
		        if(a[i, vitricot].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                       
                        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }
	        }

	        // Xét xuống dưới (dọc dưới)
            for (int i = vitridong + 1; i < sodong; ++i)
	        {
		        if(a[i, vitricot].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        
                        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }
	        }
	        return false; // chưa thắng
        }

        // vitridong: Là vị trí dòng của quân vừa đánh xuống
        // vitricot: Là vị trí cột của quân vừa đánh xuống
        bool KiemTraCheoChinh(Button[,] a, int sodong, int socot, int vitridong, int vitricot)
        {
	        int dem = 1; // Tính luôn quân vừa đánh xuống

	        // Kiểm tra chéo chính trên: Các phần tử dòng - cột luôn giảm 1 đơn vị và giảm đến khi nào 1 trong 2 thằng xuất hiện 0
	        int i = vitridong - 1;
	        int j = vitricot - 1;
	        while(true)
	        {
		        if(i < 0 || j < 0)
		        {
			        break; // vị trí xét không hợp lệ
		        }

		        // Nếu còn chạy xuống đây được thì có nghĩa vị trí i, j hợp lệ
		        if(a[i, j].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }

		        // Xét qua lần lặp mới
		        i--;
		        j--;
	        }

	        //	Kiểm tra chéo chính dưới: Các phần tử dòng - cột đều tăng lên 1 đơn vị và tăng đến khi nào 1 trong 2 thằng bằng n - 1 thì dừng lại
	        i = vitridong + 1;
	        j = vitricot + 1;
	        while(true)
	        {
		        if(i == sodong || j == socot)
		        {
			        break; // vị trí xét không hợp lệ
		        }

		        // Nếu còn chạy xuống đây được thì có nghĩa vị trí i, j hợp lệ
                if (a[i, j].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }

		        // Xét qua lần lặp mới
		        i++;
		        j++;
	        }
	        return false; // chưa thắng
        }

        // vitridong: Là vị trí dòng của quân vừa đánh xuống
        // vitricot: Là vị trí cột của quân vừa đánh xuống
        bool KiemTraCheoPhu(Button[,] a, int sodong, int socot, int vitridong, int vitricot)
        {
	        int dem = 1; // Tính luôn quân vừa đánh xuống

	        // Kiểm tra chéo phụ trên: Dòng giảm - cột tăng. Dòng giảm tối đa tới 0, Cột tăng tối đa nới n - 1
	        int i = vitridong - 1;
	        int j = vitricot + 1;
	        while(true)
	        {
		        if(i < 0 || j == socot)
		        {
			        break; // vị trí xét không hợp lệ
		        }

		        // Nếu còn chạy xuống đây được thì có nghĩa vị trí i, j hợp lệ
		        if(a[i, j].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }

		        // Xét qua lần lặp mới
		        i--;
		        j++;
	        }

	        //	Kiểm tra chéo phụ dưới: Dòng tăng - cột giảm. Dòng tăng tới tối đa là n - 1 và cột giảm tới tối đa là 0
	        i = vitridong + 1;
	        j = vitricot - 1;
	        while(true)
	        {
		        if(i == sodong || j < 0)
		        {
			        break; // vị trí xét không hợp lệ
		        }

		        // Nếu còn chạy xuống đây được thì có nghĩa vị trí i, j hợp lệ
                if (a[i, j].Text == a[vitridong, vitricot].Text)
		        {
			        dem++;

			        if(dem == 5)
			        {
                        return true; // đã thắng
			        }
		        }
		        else // chỉ cần phát hiện không còn tính liên tục => dừng quá trình lặp lại
		        {
			        break;
		        }

		        // Xét qua lần lặp mới
		        i++;
		        j--;
	        }
	        return false; // chưa thắng
        }

        bool luotdi = true; // true: X - false: O. Nếu ban đầu ở đây chúng ta để giá trị khởi tạo cho nó là true nghĩa là X đánh trước, nếu để khởi tạo cho nó là false nghĩa là O đánh trước
        
        // Là tọa độ của nút Button đầu tiên của bàn cờ (Button trên cùng, bên trái của bàn cờ)
        int vitriXbandau;
        int vitriYbandau;

        // Kích thước của 1 nút nhấn trong bàn cờ (1 ô vuông trong bàn cờ)
        int dorongcuanut = 70;
        int docaocuanut = 40;

        // Kích thước từ đầu vào của bàn cờ
        int sodong = 15;
        int socot = 15;

        // Khởi tạo mảng 2 chiều bàn cờ
        Button[,] banco;

        // Khai báo biến cấu trúc stack để hỗ trợ lưu trữ vị trí tọa độ (dòng, cột) các nước đánh để từ đó đi xử lý cho tính năng Undo
        Stack stack = new Stack();

        private void Form1_Load(object sender, EventArgs e)
        {
            // Xác định lượt đánh hiện tại là của quân cờ X hay O từ đó hiển thị ra câu thông báo trên Form cho người chơi biết
            if (luotdi == true)
            {
                lblquanco.ForeColor = Color.Red; // Tô màu đỏ cho quân cờ được đánh ra
                lblquanco.Text = "X";
            }
            else
            {
                lblquanco.ForeColor = Color.Black; // Tô màu đen cho quân cờ được đánh ra
                lblquanco.Text = "O";
            }

            // Mặc định vị trí góc trên cùng bên trái của bàn cờ sẽ nằm ngay bên dưới của nút nhấn New Game
            vitriXbandau = btnNewGame.Location.X; // Cùng tọa độ X với nút nhấn New Game
            vitriYbandau = btnNewGame.Location.Y + btnNewGame.Height + 5;

            this.Size = new System.Drawing.Size(socot * dorongcuanut + vitriXbandau + 30, (sodong + 1) * docaocuanut + vitriYbandau + 10);//vẽ bàn cờ
            
            // Cấp phát bộ nhớ cho mảng 2 chiều bàn cờ
            banco = new Button[sodong, socot];

            // Vòng lặp duyệt qua toàn bộ các Button có trong mảng 2 chiều bàn cờ
            for (int i = 0; i < sodong; ++i) // Vòng lặp duyệt qua từng dòng
            {
                for (int j = 0; j < socot; ++j) // Với từng dòng thì vòng lặp này duyệt qua từng cột
                {
                    banco[i, j] = new Button(); // Phải có dòng này bởi vì mình chỉ mới khởi tạo mảng 2 chiều Button còn từng phần tử Button trong mảng cũng phải khởi tạo cho nó nếu không khi truy xuất đến nó sẽ bị báo lỗi: "Object reference not set to an instance of an object."

                    banco[i, j].Size = new Size(dorongcuanut, docaocuanut); // Cài đặt độ lớn của nút Button bàn cờ

                    banco[i, j].Location = new Point(vitriXbandau + j * dorongcuanut, vitriYbandau + i * docaocuanut); // Phải cài đặt vị trí tọa độ xuất hiện của từng nút nhấn (ô vuông) trong bàn cờ chứ nếu không nó sẽ mặc định tất cả tại vị trí Location(1, 1) và như thế là nằm đè lên nhau chứ không phải là dạng lưới ô vuông từ trái qua phải, từ trên xuống dưới

                    banco[i, j].FlatStyle = FlatStyle.Flat; // Thuộc tính này giúp nút Button nhìn trong suốt như là đường kẻ vẽ lên

                    // Khai báo thông tin Font chữ ... => cái này nếu không nhớ thì copy bên form Designer.cs sửa lại đối tượng trỏ tới là xong
                    banco[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    banco[i, j].Click += Form1_Click; // Gán tất cả sự kiện của các Button sẽ được định nghĩa trong hàm có tên là Form1_Click   

                    this.Controls.Add(banco[i, j]); // Hiển thị nút Button vừa được tạo ra đó lên giao diện Form
                }
            }
        }

        void Form1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // sender hiểu là chính đối tượng mình đang thao tác trên nó. Do nó đang là kiểu Object cho nên phải ép kiểu sang kiểu Button rồi gán qua cho 1 biến đại diện là btn từ đó cứ làm việc trên biến btn là được

            if (btn.Text != "") // Mặc định khi tạo ra các Button chúng ta không tạo thuộc tính Text thì mặc định nó là rỗng vì thế ở đây chúng ta kiểm tra nếu ô mà chúng ta click xuống mà Text nó khác rỗng tức là ô đó đã có quân cờ rồi cho nên không được đánh
            {
                MessageBox.Show("Ô này đã có quân cờ tồn tại nên không đánh được");
            }
            else // ô này chưa có quân cờ => được phép đánh
            {
                if (luotdi == true) // Lượt đi của X
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Red; // Quân X sẽ có màu đỏ, còn quân cờ O sẽ mặc định là màu đen vì màu đen cũng là màu mặc định cho nên mình khỏi cần khai báo thuộc tính
                }
                else // Lượt đi của O
                {
                    btn.Text = "O";
                }

                // Tính toán vị trí tọa độ dòng - cột của ô vừa đánh cờ xuống để mục đích gọi lại 4 hàm kiểm tra theo đường ngang, dọc, 2 đường chéo và truyền đúng tham số tọa độ dòng - cột của ô vừa đánh
                int toado_dong = (btn.Location.Y - vitriYbandau) / docaocuanut;
                int toado_cot = (btn.Location.X - vitriXbandau) / dorongcuanut;

                ToaDo toadoquanco;
                toadoquanco.toado_dong = toado_dong;
                toadoquanco.toado_cot = toado_cot;

                stack.Push(toadoquanco); // Đưa nguyên biến cấu trúc vào trong stack

                // Sau khi đã đánh quân cờ xuống thì đi kiểm tra xem có chiến thắng chưa? Dòng lệnh kiểm tra này phải để trước dòng cập nhật lại lượt đi để nó kết luận đúng được lượt đi đó là của quân cờ nào chiến thắng
                if (KiemTraHangNgang(banco, socot, toado_dong, toado_cot) == true
                    || KiemTraHangDoc(banco, sodong, toado_dong, toado_cot) == true
                    || KiemTraCheoChinh(banco, sodong, socot, toado_dong, toado_cot) == true
                    || KiemTraCheoPhu(banco, sodong, socot, toado_dong, toado_cot) == true)
                {
                    MessageBox.Show((luotdi == true ? "X" : "O") + " đã chiến thắng"); // Toán tử 3 ngôi để biết lượt đi hiện tại là của X hay O từ đó kết luận chiến thắng
                    
                    // Sau khi đã có kết luận chiến thắng thì chúng ta sẽ không cho phép người dùng tương tác với các Button bàn cờ nữa vì ván cờ đã kết thúc
                    // => Duyệt qua danh sách các Button của bàn cờ và kích hoạt cho nó endable = fasle để mờ đi không bấm vào được nữa
                    for (int i = 0; i < sodong; ++i)
                    {
                        for (int j = 0; j < socot; ++j)
                        {
                            banco[i, j].Enabled = false; // không cho tương tác click vào
                        }
                    }
                    btnUndo.Enabled = false;
                }

                luotdi = !luotdi; // Phủ định lại chính nó rồi cập nhật lại => mục đích là để lượt đánh luân phiên nhau cứ true (X) - false (O) - true (X) - false (O) cứ thế ...

                // Cứ mỗi lần có thay đổi lại lượt đi là lại xác định lượt đánh hiện tại là của quân cờ X hay O từ đó hiển thị ra câu thông báo trên Form cho người chơi biết
                if (luotdi == true)
                {
                    lblquanco.ForeColor = Color.Red; // Tô màu đỏ cho quân cờ được đánh ra
                    lblquanco.Text = "X";
                }
                else
                {
                    lblquanco.ForeColor = Color.Black; // Tô màu đen cho quân cờ được đánh ra
                    lblquanco.Text = "O";
                }

                // Kiểm tra xem là nước đánh đó có phải là nước đánh cuối cùng hay không?\
                if (stack.Count == sodong * socot)
                {
                    MessageBox.Show("Bàn cờ đã hết chỗ để đánh" + (banco[0, 0].Enabled == true ? ". 2 đấu thủ hòa nhau" : ""));
                }

                //MessageBox.Show("Đang click vào nút có tọa độ dòng: " + toado_dong.ToString() + " - tọa độ cột: " + toado_cot.ToString());
        
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            // Ở đây hiện tại nếu new game lại sau khi đã có kết quả thắng/thua trước đó thì nước đánh đầu tiên sau khi new game sẽ là nước đánh của người thua (bởi vì đó là nước đánh tiếp theo sau người thắng). Nếu Bạn không muốn điều này mà muốn lúc nào cũng cố định là true (X) đi trước thì trong sự kiện Click của nút nhấn New Game này Bạn phải reset lại luotdi = true
            if (banco[0, 0].Enabled == true) // tức là chưa có kết quả thắng/thua mà bấm vào New Game thì sẽ mặc định lượt đi là true (X)
            {
                luotdi = true;
            }

            // Cứ mỗi lần có thay đổi lại lượt đi là lại xác định lượt đánh hiện tại là của quân cờ X hay O từ đó hiển thị ra câu thông báo trên Form cho người chơi biết
            if (luotdi == true)
            {
                lblquanco.ForeColor = Color.Red; // Tô màu đỏ cho quân cờ được đánh ra
                lblquanco.Text = "X";
            }
            else
            {
                lblquanco.ForeColor = Color.Black; // Tô màu đen cho quân cờ được đánh ra
                lblquanco.Text = "O";
            }


            // Khi nhấn vào nút New Game thì sẽ cho hiện lại danh sách các Button để có thể đánh cờ lại từ đầu với 1 ván chơi mới
            // Duyệt qua danh sách các Button của bàn cờ để reset lại từ đầu
            for (int i = 0; i < sodong; ++i)
            {
                for (int j = 0; j < socot; ++j)
                {
                    banco[i, j].ForeColor = Color.Black; // Cho về lại hết màu đen mặc định ban đầu
                    banco[i, j].Text = ""; // Reset lại các quân cờ về rỗng
                    banco[i, j].Enabled = true; // cho phép tương tác click vào
                }
            }

            // Reset lại stack về rỗng
            stack.Clear();

            btnUndo.Enabled = true;
        }

        //  Tính năng Undo: Nó sẽ cho phép liên tục lùi lại các nước đã đánh ở lần gần nhất vừa đánh và cứ thế càng nhấn nó sẽ càng lùi về nước đầu tiên cho đến khi lùi hết nước đầu tiên thì hết cái để Undo
        private void btnUndo_Click(object sender, EventArgs e)
        {
            // Chỉ có thể lấy được phần tử ra khỏi Stack nếu Stack đó không bị rỗng (tức là số lượng phần tử tồn tại bên trong > 0). Nếu không có cái if này sẽ bị văng lỗi chương trình nếu như trong stack không còn phần tử nào mà lại đi lấy ra
            if (stack.Count > 0)
            {
                ToaDo toadoquancovuadanh = (ToaDo)stack.Pop(); // Lấy đối tượng đầu stack ra. Vì là kiểu Object nên mình phải ép kiểu sang kiểu tương ứng

                banco[toadoquancovuadanh.toado_dong, toadoquancovuadanh.toado_cot].Text = ""; // Xóa quân cờ vừa đánh gần nhất

                banco[toadoquancovuadanh.toado_dong, toadoquancovuadanh.toado_cot].ForeColor = Color.Black; // Reset lại về màu đen

                luotdi = !luotdi; // Sau khi xóa quân cờ vừa đánh gần nhất đi để đánh lại thì cũng phải cập nhật lại lượt đánh là lượt đánh của lần đánh trước đó (giả sử O vừa đánh xong tiếp theo sẽ là X thì nếu xin phép Undo thì tiếp theo phải là O chứ không phải là X)

                // Cứ mỗi lần có thay đổi lại lượt đi là lại xác định lượt đánh hiện tại là của quân cờ X hay O từ đó hiển thị ra câu thông báo trên Form cho người chơi biết
                if (luotdi == true)
                {
                    lblquanco.ForeColor = Color.Red; // Tô màu đỏ cho quân cờ được đánh ra
                    lblquanco.Text = "X";
                }
                else
                {
                    lblquanco.ForeColor = Color.Black; // Tô màu đen cho quân cờ được đánh ra
                    lblquanco.Text = "O";
                }

                //MessageBox.Show("Lần đánh gần nhất là ở vị trí tọa độ dòng: " + toadoquancovuadanh.toado_dong.ToString() + " - tọa độ cột: " + toadoquancovuadanh.toado_cot.ToString());
            }
        }
    }
}
