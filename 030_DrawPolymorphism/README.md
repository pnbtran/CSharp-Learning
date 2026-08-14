# 030 BÀI TẬP TÍNH ĐA HÌNH: PHƯƠNG THỨC DRAW() CHO CÁC HÌNH KHÁC NHAU

## Tóm tắt
- [1] Tạo lớp trừu tượng (Abstract class - AC) và phương thức trừu tượng (Abstract method - AM) 

- [2] Lí do không được dùng `new` trong 1 AC 

- [3] Ghi dè (override) `Draw()` cho từng hình cụ thể

- [4] Dùng mảng đa hình gọi `Draw()` cho mọi hình bằng vòng lặp

- [5] Thêm AM có giá trị để trẻ về giá trị  cần thiết  và kết hợp LINQ

- [6] Phân biệt 3 công cụ trừu trượng: *Abstract class* vs *Interface* vs *virtual*

## Lý thuyết 
### Nếu lớp cha "chung chung một cách nguy hiểm" thì sẽ như nào? 
- Mình viết `Class Shape` có `Draw()` chung rồi cho lớp con kế thừa? Nghe vô cùng *"hợp lí, đến mức đáng nghi"*, nhưng khi đó vấn đề gặp phải: 
    - Lớp `Shape` chung chung thì *vẽ ra cái gì*? Không có "hình học chung chunh"

    - Nếu mình tạo thêm `new class` rồi gọi `Draw()` --> Chương trình chẳng vẽ ra gì có nghĩa hoặc quên luôn `Draw()`

    - Cách khắc phục: *Dùng Abstract class*. 

- **Abstract class** = bản thiết kế, *cấm* tạo ra object từ nó nhưng *bắt buộc* mọi hình con tự định nghĩa cách vẽ riêng. 

| Cách làm | Vấn đề | 
|----------|--------| 
| `Shape` thường + `Draw()` rỗng | Có thể `new Shape()` sai, class con quên `override` nhưng không báo lỗi | 
| `Shape` thường + `Draw()~ là `virtual` | Class con có thể `override` nhưng không bắt buộc -> dễ sót | 
| `Shape` abstrsct + `Draw()` abstract | Cấm `new Shape()`, nhưng class con bắt buộc override, quên là lỗi biên dịch | 

### Class abstract - lớp trừu tượng 
- Là một class có ít nhất một phương thức abstract, cả class cần phải khai báo abstract. Nếu ở đầu không khai báo abstract + trong lại khai báo method abstract --> lỗi biên dịch 

```csharp
public abstract class Shape   // abstract = KHÔNG tạo object trực tiếp
{
    // Phương thức TRỪU TƯỢNG - không có thân, lớp con BẮT BUỘC override
    public abstract void Draw();

    // Phương thức THƯỜNG - lớp con dùng chung được (kế thừa code sẵn)
    public void DisplayInfo() => Console.WriteLine("Đây là một hình học");
}
```
**🚨 Lưu ý**
- Cú pháp `public abstract void Draw();` cần kết thúc `;` và không có cặp `{}` - giống cách khai báo **Interface** 

- Khác với **Interface**, **Abstract class** còn chứa được phương thức thường (*có thân*), thuộc tính và constructor. 

## Thuật toán
- [1] Khởi tạo Abstract class

- [2] Khởi tạp class con chứa phương thức bắt buộc vẽ 
    - Mỗi hình con - thuộc tính và cách vẽ riêng

    - Tất cả đều cam kết `Draw()` --> Method abstract bắt buộc *tuyệt đối* 

- [3] Phương thức đa hình, tại hàm `Main` 
    - `shape.Draw()` - khi này trình biên dịch không biết trước shape cụ thể. Chỉ chạy .NET và nhìn object thật để vẽ `Draw()` theo từng class con cụ thể --> cơ chế **liên kết muộn (late binding)** 

- [4] Thêm cách tính diện tích `GetArea()` - `method abstract` + LINQ 
    - Method abstract: `GetArea()`

    - LINQ: `Sum, Where, Count` 

## Lưu ý/ Tổng kết
- **Abstract class** không tạo object trực tiếp được; **abstract method** không có thân, bắt buộc lớp con `override` - hoàn hảo cho “khung chung, chi tiết riêng”.  

- **Phân biệt 3 khái niệm trừu tượng OOP: abstract vs interface vs virtual**

| -- | Virtual | Abstract | Interface | 
|----|---------|----------|-----------|
| Có thân hàm sẵn? | Có (con có thể **override**) | | Không (con bắt buộc thể **override**) | Không (mặc định) | 
| Tạo object? | Được | Không | Không | 
| Chứa code chung + thuộc tính? | Có | Có | Không | 
| Số lượng kế thừa | 1 class cha | 1 class cha | nhiều Interface | 

> 💡 Cách chọn *thực dụng*: 
>    
>    Dùng **virtual** khi lớp cha có sẵn cài đặt mặc định mà con có thể muốn đổi; 
>   
>    **Abstract** khi lớp cha là khái niệm chung không nên tạo object và con bắt buộc tự cài; 
>    
>    **Interface** khi định nghĩa “năng lực” cho các lớp không cùng cha. Thiết kế thật thường dùng cả ba, chúng bổ sung cho nhau. 

### Các bước để triển khai đa hình cho phương thức Draw() trong C# theo đúng thứ tự  
- [1] Khai báo Draw() là virtual trong Shape
```csharp
class Shape
{
    public virtual void Draw() { }
}
```

- [2] Tạo Circle kế thừa Shape
```csharp
class Circle : Shape
```

- [3] Circle override Draw()
```csharp
public override void Draw()
{
    Console.WriteLine("Ve hinh tron");
}
```

- [4] Tạo object Circle rồi gán cho biến kiểu Shape
```csharp
Shape shape = new Circle();
```

- [5] Gọi Draw() thông qua biến Shape → lúc này đa hình mới được thể hiện.
```csharp
shape.Draw();
```


## Lỗi vô tri đã phát giác
### Error 1 - Quên override GetArea() ở class con
- [x] Sai: “Lớp con kế thừa abstract class có thể bỏ qua abstract method nếu chưa cần dùng.”

- [v] Đúng: Bắt buộc override mọi abstract method, nếu không sẽ lỗi biên dịch (trừ khi lớp con cũng khai báo abstract để “chuyền” nghĩa vụ xuống lớp cháu). 

- Cuh thể 
```txt
Shape
 ├── Draw()
 └── GetArea()
       ↓
Triangle
 ├── Draw()       → đã override
 └── GetArea()    → thiếu
                    ↓
                 CS0534
```
- **Lỗi** khi code
```csharp
internal class Program
{
    public abstract class Shape
    {
        public abstract void Draw();

        public abstract double GetArea();  // Abstract method 
    }

public class Triangle : Shape
{
    // định nghĩa hình tam giác ở đây (đáy, cao)
    public override void Draw()
    {
        Console.WriteLine("Ve HINH TAM GIAC");
    }

    // Không override GetArea() → lớp Triangle chưa triển khai đầy đủ hợp đồng của Shape
}
``` 
- 
    - **Compiler** báo lỗi 
```txt 
CS0534 does not implement inherited abstract member '...GetArea()'
``` 
- **CODE ĐIỀU CHỈNH** thêm phần tính diện tích
```csharp 
 public class Triangle : Shape
 {
    // Khai báo định nghĩa + vẽ 
     public override double GetArea()
     {
         return 0.5 * Base * Height;
     }
 }
```

### Error 2 - `base` không phải tên biến bình thường :(((
- [x] Sai: dùng `base` làm tên parameter

- [v] Đúng: đổi tên parameter: thêm `@` để escape keyword

- **Lỗi** khi code
```csharp
public Triangle(double base, double height)
{
    Base = base;
    Height = height;
}
``` 
- **Compiler** báo lỗi vì `base` là keyword của C# để truy cập thành phần class cha 

- **CODE ĐIỀU CHỈNH**
```csharp
public Triangle(double @base, double height)
{
    Base = @base;
    Height = height;
}
```
- **Lưu ý**: 
    - `base` → keyword dùng để truy cập thành phần của class cha.

    - `Base` → tên property của mình → hoàn toàn hợp lệ.

    - `baseLength` → tên parameter → rõ nghĩa, nên ưu tiên dùng. Nhưng tui lười nên gõ `@base` thay cho `baseLength` ở phần điểu chỉnh. 