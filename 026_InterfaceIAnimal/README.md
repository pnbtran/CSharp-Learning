# 026 LẬP TRÌNH OOP VỚI INTERFACE IANIMAL
## Tóm tắt
- Interface là gì? Lợi ích?  

- Cách triển khai Interface với phương thức và thuộc tính 

- Triển khai (implement) - một interface trong các lớp `Dog` và `Cat` 

- Dùng Interface cho đa hình 

## Tổng quan Interface 
- Hiểu Interface = bản hợp đồng khái báo những định nghĩa phương thức/ thuộc tính mà lớp triển khai phải có.

- Đặc điểm: 
    - Chi khai báo: phương thức trong Interface không có thân hàm, chỉ khết thúc bằng `;`

    - Không tạo object trực tiếp: không thể viết `new IAnimal()`, vì Interface không phải lớp cụ thể

    - Implement nhiều: một lớp có thể kí nhiều Interface cùng lúc

    - Quy ước tên: Bắt đầu chữ `I` viết hoa (IAnimal, IComparable, IDisposable,...)

## Thuật toán
- [1] Khai báo Interface 

    Trong phần khai báo, `void MakeSound();` chí kết thúc bằng `;` chứ không có `{}` - quy định đặc tính ban đầu 

- [2] Triển khai Interface trong class Dog và Cat 

> ⚠️ Nếu một lớp : `IAnimal` mà quên cài đặt `MakeSound()` (hoặc bất kỳ thành viên nào trong hợp đồng) -> trình biên dịch báo lỗi ngay lập tức, kiểu `'Dog' does not implement interface member 'IAnimal.MakeSound()'`. **Interface là bắt buộc, không có chuyện “ký rồi mà không làm”!** 

- [3] Đa hình, triển khai ở hàm `Main` 

    -  Một class có thể kết hợp với nhiều Interface

    ```csharp 
    public class Cat : IAnimal, IPet
    ```

    > Lúc này Cat có đủ phương thức của `IAnimal` và cả `IPet` (vừa biết ăn, ngủ, kêu... lại còn biết chơi).  

    - So sánh class kế thừa và Interface

| So sánh | Kế thừa Class | Interface | 
|---------|---------------|-----------|
| Số lượn cha | 1 và chỉ 1 | Nhiều Interface | 
| Cho gì | thừa hưởng code sẵn | chỉ hợp đồng, tự cài | 
| Ý nghĩa | "là một" quan hệ (is-a) | "có khả năng" (Can-do) | 

    > Trong C# không cho phép đa kế thừa, nhưng lại cho implement nhiều interface 

### Nhìn sâu hơn 
- Interface với abstract class (lớp trừu tượng) trông giống nhau, vậy chọn nào? 
    > Cả hai đều là công cụ làm tính "trừu tượng" nhưng khác bản chất 

    - Abtract class: khuôn mẫu hoàn thiện, chứa sẵn code (phương thức có thân), trường dữ liệu, hàm constructor và để lại vài phương thức `abtract` cho class con hoàn thiện. Nhưng class con chỉ được phép kế thừa 1 abtract class. 

    - Interface: hợp đồng (không có code) chỉ quy định chuẩn cho class cam kết, 1 implement được quyền có nhiều interface. 

    --> Cùng 1 họ và chia sẻ code chung, thì chọn `abtract class`. Còn không cùng cha nhưng nhiều năng lực thì interface. 