# 023 XÂY DỰNG CLASS VEHICLE 
## Tóm tắt
- Tính kế thừa và quan hệ (is-a) trong OOP

- Viết lớp con kế thừa lớp cha bằng dấu `:`

- Dùng từ khóa `base(...)` để gọi constructor của lớp cha

- Gọi lại logic của cha bên trong bản ghi đè `base.MethodName()`

## Tính kế thừa
- Kế thừa là cho phép một lớp (lớp con hay lớp dẫn xuất) thừa hưởng toàn bộ thuộc tính và phươqng thức **public/protected** của một lớp khác (lớp cha hay lớp cơ sở)

- Ý nghĩa
    - Tái dùng code: viết phần chung 1 lần tại lớp cha, diễn tả tính chung mọi lớp con bên trong

    - Dễ bảo trì: sửa logic chung ở một chỗ

    - Tổ chức khoa học: nhóm các lớp liên quan thành 1 nhóm lớn

    - Dễ mở rộng: thêm loại xe mới chỉ cần kế thừa phần chung và bổ sung phần riêng

- Cú pháp dùng dấu `:` (hiểu là: kế thừa từ)

```csharp 
class LopCon : LopCha
{
    //
}
```
## Thuật toán
- [1] Xây dựng lớp cha Vehicle

> Từ khóa `virtual` đánh dấu phương thức lớp con có thể "ghi đè"
> `DisplayInfo` in thông tin giống nhau cho mọi xe không cần `virtual`

- [2] Xây dựng lớp car và motorcycle (kế thừa và bổ sung)
    - `:` khai báo lớp con kế thừa lớp cha

    - `base(...)` gọi constructor của lớp cha để tạo phần chung

    - `override`: ghi đè một phương thức `virtual` của lớp cha, làm nó cư xử khác đi

- [3] Khai báo đối tượng và in ở hàm `Main`

## Quan hệ "is-a" và tính đa hình
- Cấu trúc thể hiện tính kế thừa

```txt
   Vehicle (cha): Brand, Model, Start(), DisplayInfo()   -- phần CHUNG
       |  kế thừa (:)
   +---+--------------------------+
   |                              |
   Car (con)                 Motorcycle (con)
   + NumberOfDoors            (phần riêng)
   + override Start()        + override Start()

```
> Kế thừa mô hình hóa quan hệ **“là một” (is-a)**: `Car` là một `Vehicle`, `Motorcycle` cũng vậy. Nhờ đó, có thể gom cả ô tô lẫn xe máy vào cùng một mảng kiểu `Vehicle[]`, rồi duyệt qua gọi `Start()` - mỗi xe khởi động theo kiểu riêng @@ 

- Dùng lệnh `v.Start()` thể hiện tính đa hình (polymorphism) - các đặc điểm riêng của đối tượng thuộc lớp con. Khi đó, đoạn code lớp con vừa có tính kế thừa đặc điểm chung vừa thể hiện đặc điểm riêng đối tượng.

## Lưu ý

- **Sai**: `override` dùng được với bất kỳ phương thức nào của lớp cha.

  **Đúng**: Chỉ `override` được phương thức mà lớp cha đánh dấu là `virtual` (hoặc `abstract`). Không có `virtual` thì không được `override`

- **Sai**: Constructor của lớp con tự động khởi tạo phần dữ liệu của cha giúp mình

  **Đúng**: Cần dùng `base(...)` để truyền dữ liệu lên constructor lớp cha. Nếu lớp cha không có constructor mặc định mà bạn quên gọi `base(...)`, code sẽ báo lỗi biên dịch.

- Đừng lạm dụng kế thừa nhiều tầng (cha - con - cháu - chắt…). Cây kế thừa quá nhiều nhánh, khiến code khó theo dõi. 

- Cách nhớ: `“con : cha” (dấu hai chấm để kế thừa), “virtual ở cha, override ở con”, “base() gọi cha”, và “is-a mới kế thừa”`