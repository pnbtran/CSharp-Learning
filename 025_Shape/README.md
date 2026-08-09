# 025 BÀI TẬP KẾ THỪA: CLASS SHAPE
## Tóm tắt 
- Xây cây kế thừa `Shape -> Circle, Rectangle`

- Thực hành ghi đè bằng `virtual/ override` 

- Hiểu đa hình: một mảng `Shape[]` có thể chứa nhiều loại hình, mỗi loại có 1 bài toán riêng

- Thực hành dùng `base` để gọi thành phần class cha phía trên

- Thử nguyên tắc Open/Closed 

## Thuật toán
- **[1] Class shape** - khuôn chung cho cả bài
    `GetArea()` ở `Shape` trả về 0 và đánh dấu `virtual`, như "lời hứa" mọi hình đều được tính diện tích, nhưng cách tính do lớp con quyết định. 

- **[2] Class Circle và class Rectangle** 
    - `base.ToString()` gọi phương thức `ToString()` của lớp cha (Shape) rồi ghép thêm phần riêng của hình tròn. Nhờ vậy ta tái dùng phần “Hình màu… tô đầy” đã viết ở cha, thay vì gõ lại. Từ khóa base chính là “đường dây nóng” nối thẳng tới lớp cha.

    - Lưu ý : `base(color, isFilled)` ở hàm tạo. Đây là cách lớp con “nhờ” lớp cha khởi tạo phần chung (màu, trạng thái tô) trước, rồi con mới lo phần riêng (bán kính). Nếu quên gọi base(...), C# sẽ cố gọi hàm tạo mặc định của cha - nên nếu cha không có hàm tạo mặc định thì code báo lỗi biên dịch ngay.

    - Cẩn thận: Nếu quên chữ `override` mà chỉ viết `public double GetArea()` ở lớp con, C# sẽ hiểu đó là một phương thức MỚI che khuất (hide) phương thức cha, chứ không phải ghi đè. Khi đó đa hình gãy: gọi qua biến kiểu Shape sẽ chạy bản của cha (trả về 0). Trình biên dịch sẽ nhắc bạn bằng một cảnh báo warning - đừng phớt lờ nó! 

- **[3] Hàm main**

## Tính đa hình (polymorphism) của OOP
```txt
   KHÔNG đa hình:
     if      (hình là Circle)     tính pi nhân r bình phương
     else if (hình là Rectangle)  tính dài nhân rộng
     else if (hình là Triangle)   tính 0.5 nhân đáy nhân cao
     else if (...)  -> thêm loại nào là phải mở lại đống if này để sửa!

   CÓ đa hình:
     hinh.GetArea()  -> mỗi hình tự lo công thức của mình
                     -> thêm loại mới KHÔNG cần đụng vào code cũ
``` 

- Nếu không dùng tính đa hình, mỗi lần thêm dạng hình mới vào là lại `if-else` kiểm và sửa từng chút, "lỡ sót là tìm lỗi mờ mắt" --> ác mộng lúc cần kiểm tra, sửa chửa

- Đa hình, có thể làm gọn, không cần phải nhiều dòng `if-else` 

- Tạm nhớ: `virtual` ở cha, `override` ở con. `Shape[]` chứa mọi con. Cùng lệnh, khác hành vi = đa hình.