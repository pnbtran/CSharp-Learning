# 029 SỬ DỤNG LINQ ĐỂ LỌC DANH SÁCH TRONG C#
## Tóm tắt
- LINQ (Language Integrated Query) cho phép truy vấn dữ liệu (lọc, sắp xếp, tính tổng,...) ngay trong code theo phong cách gần giống SQL "thanh lịch, ngắn gọn, dễ đọc" (?) 

> LINQ = truy vấn dữ liệu kiểu SQL ngay trong C#; Where (lọc), Select (chọn/biến đổi), OrderBy (sắp xếp) - một dòng thay cả vòng lặp.

- Thực hành lọc danh sách bằng `Where` và các phương thức `Select`, `OrderBy`, `Sum`, `Count`, `Fist`, `Any`

- Học cách viết LINQ theo cả Query Syntax (giống SQL) và Method Syntax (dùng phương thức)

## Lợi ích LINQ 
- Nếu cần lọc số chẵn, thông thường, mình sẽ viết `foreach + if + add` vào danh sách tạm, lặp đi lặp lại --> không thông minh nếu cần nhiều

- LINQ sẽ giúp mình viết gọn hơn
```csharp
var soChan = numbers.Where(num => num % 2 == 0); 
```

- Cách viết LINQ, cần khai báo thư viện `using System.Linq;` 
    [1] Cách 1: Query Syntax - `from n in list where n > 5 select n`: câu lệnh SQL

    [2] Cách 2: Method Syntax - `list.Where(n => n>5)` - gọi phương thức + lambda 

    -> Cả hai cho kết quả giống nhau. Trong thực tế, Method Syntax phổ biến hơn vì gọn và nối chuỗi được (?) 

## Thuật toán
- [1] Viết Lọc cơ bản với Where - hai cách viết

- [2] Thao tác `Where, Select, OderBy` và các phép tổng hợp 
    - (1) `Where` - Lọc thõa mãn điều kiện, `.Where(n => n > 5)`

    - (2) `Select` - Chọn/biến đổi (projection), `.Select(p => p.Name)`

    - (3) `OrderBy` - Sắp xếp tăng dần, `.OrderBy(n => n)`

    - (4) `OrderByDescending` - Sắp xếp giảm dần, `.OrderByDescending(p => p.Price)`

    - (5) `Sum` - Tính tổng, `.Sum()`

    - (6) `Count` - Đếm số phần tử, `.Count(n => n>4)`

    - (7) `Max/ Min` - Lớn nhất/ Nhỏ nhất, `.Max()`

    - (8) `Average` - Trung bình cộng, `.Average()`

    - (9) `First` - Lấy phần tử đầu tiên thỏa điều kiện, `.First(n => n > 4)`

    - (10) `Any` - Có phần tử nào thỏa điều kiện không?, `.Any(n =>n > 100)`

```md
 Sức mạnh thật sự là nối chuỗi (chaining): `Where().OrderBy().Select()`... đọc như một câu văn trôi chảy. Nhớ thêm `.ToList()` ở cuối nếu muốn kết quả là một List cụ thể - vì mặc định LINQ trả về kiểu “lười” cho tới khi bạn duyệt hoặc chuyển đổi 
```

- Viết LINQ cho class Product 
> `Select(p => p.Name)` biến đổi mỗi product thành tên của nó - đây là “phép chiếu” (projection).

## Tóm tắt/ Lưu ý 
- Sơ đồ LINQ
```txt
   Dữ liệu nguồn (List, mảng...)
              │
              ▼  .Where(...)      LỌC theo điều kiện
              ▼  .OrderBy(...)    SẮP XẾP
              ▼  .Select(...)     CHỌN / BIẾN ĐỔI
              ▼  .ToList()        CHỐT SỔ -> danh sách kết quả

   Tổng hợp: Sum() | Count() | Max() | Min() | Average() | First() | Any()
```
- Lưu ý:
    - Các câu lệnh truy vấn `Where`, `Select`,... chưa chạy ngay khi viết, mà khi chạy chỉ thực hiện duyệt kết quả bằng `foreach`, `.ToList()`, `.Count`

    - Cơ chế thực thi trì hoãn (deferred execution): tiện, mạnh nhưng cũng dễ xuất hiện lỗi khó kiểm soát. Cần "khóa an toàn" bằng `.ToList()` hoặc `ToArra()` để thực thi ngay và lưu kết quả cố định, để nếu sau đó dữ liệu nguồn thay đổi cũng không ảnh hưởng. 

- Một số hiểu lầm: 
    - [x] LINQ là ngôn ngữ lập trình riêng
      [v] LINQ tính năng C# kết hợp lambda

    - [x] Kết quả `Where` tự động là `List
      [v] Các operator LINQ to Objects như `Where, Select, OrderBy` thường trả về một `IEnumerable<T>` và được thực thi trì hoãn. Thêm `.ToList()` nếu muốn trả dữ liệu kiểu `List` 

    - Where lọc, Select chọn, OrderBy sắp” - còn Sum/Count/First là bộ tổng hợp. Nối chuỗi rồi kết bằng .ToList()