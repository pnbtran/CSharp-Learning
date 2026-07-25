# 011_TÍNH TỔNG TỪ 2 SỐ

## Tóm tắt 
- Học cách viết phương thức có kiểu trả về, tham số và `return`.
- Gọi phương trình từ `Main` và truyền vào giá trị. 
- Hiểu nạp chồng phương thức (cùng tên, khác than số).
- Phân biệt tham số (parameter) và đối số (argument).

## Bài giảng
- **1. Phương thức** (method) - khối code thực hiện **một tác vị cụ thể**, giúp tổ chức code thành các phần nhỏ hơn, có thể **tái sử dụng và bảo trì** khi cần. 

```csharp
// Phương thức tính tổng hai số nguyên
static int TinhTong(int soThuNhat, int soThuHai)
{
    int ketQua = soThuNhat + soThuHai;
    return ketQua;   // trả kết quả về nơi gọi
}
```
Trong đó: 
| Thành phần | Vai trò |
|------------|---------|
| `static` | Gọi được mà không cần tạo đối tượng |
| `int` | **Kiểu dữ liệu** được trả về | 
| `TinhTong` | Tên phương phức | 
| `(int soThuNhat, int soThuHai)` | **Tham số** - nguyên liệu đầu vào | 
| `return KetQua` | Kết quả trả về | 

- **Nạp chồng**: cho phép thực hiện nhiều phương thức miễn khác tham số
```Csharp
static int TinhTong(int a, int b)         => a + b;        // hai số nguyên
static double TinhTong(double a, double b) => a + b;        // hai số thực
static int TinhTong(int a, int b, int c)   => a + b + c;    // ba số nguyên
```
> Cùng phương thức tính tổng, nhưng tổ chức tham số khác nhau 
> Tham số (parameter) biến định nghĩa hàm `(int a, int b)`. 
> Đối số (argument) giá trị thật khi được gọi `TinhTong(a, b)`

## Lưu ý
- Phương thức viết **ngang hàng** với `Main` (cùng trong class), không được lồng trong `Main`. Mỗi phương thức làm một việc và cần đặt tên rõ ràng. 

- Phương thức `void` không trả về gì, chỉ thực hiện công việc. 

- Nạp chồng cần khác danh sách tham số (số lượng/ kiểu) nếu trùng sẽ lỗi. 

- Tham số định nghĩa `int a`, đối số là giá trị truyền vào gọi là `Sum` chẳng hạn. 