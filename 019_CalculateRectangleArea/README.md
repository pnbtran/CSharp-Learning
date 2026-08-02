# 019 _ XÂY DỰNG LỚP HÌNH CHỮ NHẬT
## Tóm tắt
- Viết class với thuộc tính và phương thức

- Cho object tự xử lí dữ liệu của nó

- Tìm hiểu và hàm `constructor` (hàm khởi tạo)

- Phân biệt object có và không có hàm `constructor`

- OOP = đóng gói + xử lí dữ liệu

## Thuật toán 

- Class Rectangle với phương thức. 

> Phương thức CalculateArea nằm bên trong class, nên nó dùng thẳng Width và Height của chính object - không cần truyền tham số. Object “biết” dữ liệu của mình.

- Tạo và dùng object 

```csharp
public class Rectangle
{
    public double Width;
    public double Height;
    public double CalculateArea()
    {
        return Width * Height;
    }
}    
static void Main(string[] args)
{
    Rectangle rect1 = new Rectangle();
    rect1.Width = 6.3;
    rect1.Height = 3.2;

    double area = rect1.CalculateArea();
    Console.WriteLine($" Dien tich hinh chu nhat: {area}");
}
``` 

### Vai trò hàm constructor
- Khi không có hàm constructor -> chúng ta cần gán từng thuộc tính trong hàm `main`. Ví dụ như, đoạn code trên: 

```csharp 
    Rectangle rect1 = new Rectangle();
    rect1.Width = 6.3;
    rect1.Height = 3.2;
``` 
> Tuy nhiên, với các đối tượng có nhiều thuộc tính, thì việc gán từng đối tượng là vô cùng rắc rối. 

- Constructor giúp bạn làm gọn này. Ví dụ,: 

 > 1. Tạo constructor trong class Rectangle
```csharp
public Rectangle(double width, double height)
{
    Width = width;
    Height = height;
}
```

 > 2. Phần gán trong `main`
``` csharp
Rectangle rect = new Rectangle(6.3, 3.2);
```

 > 3. Lý do Constructor tiện lợi trong OOP
- Muốn tạo class Hình chữ nhật: Hình chữ nhật -> chiều dài -> chiều rộng -> diện tích

    - Khi không có constructor: Tạo hình chữ nhật -> gán chiều dài -> gán chiều rộng -> gán diện tích

    - Khi có constructor: Tạo hình chữ nhật -> Nhập: chiều dài, chiều rộng, diện tích -> hình chữ nhật hoàn chỉnh

- Vai trò constructor: Khởi tạo + gán + chuẩn bị --> đối tượng sẵn sàn sử dụng. Đây cũng là tính đóng gói (encapsulation) trong OOP.

- Constructor là phương thức đặc biệt: tên trùng tên class, không có kiểu trả về (kể cả void), và tự động chạy khi bạn gọi new. Nó dùng để thiết lập giá trị ban đầu - đảm bảo object vừa sinh ra đã “đầy đủ”, không bị thiếu dữ liệu.
