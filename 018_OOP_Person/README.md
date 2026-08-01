# 018 _ TẠO CLASS NGƯỜI VỚI THUỘC TÍNH TÊN, TUỔI
## Tóm tắt
- Phân biệt **class** và **object**.
- Khai báo class với thuộc tính (property) `{get; set;}`
- Tuy cập thuộc tính qua dấu chấm.
- Hiểu cơ bản về lập trình hướng đối tượng OOP.

## Thuật toán
- Khai báo class Person
```csharp
public class Person
{
    public string Name { get; set; }    // thuộc tính Name (chuỗi)
    public int Age { get; set; }        // thuộc tính Age (số nguyên)
}
```
Trong đó: 

    - `public`: cho phép truy cập ở bất cứ đâu trong chương trình. 
    
    - `string/ int`: kiểu dữ liệu của thuộc tính. 
    
    - `{get; set;}: cú pháp "auto-property" - cho phép đọc (get) và gán (set) -> Khai báo thuộc tính chuẩn, gọn ràng. 

## Lưu ý 
- Class = bản thiết kế (khuôn mẫu); Object = sản phẩm thật tạo từ class bằng new. Class gói thuộc tính (dữ liệu) + phương thức (hành vi) vào một chỗ.
