# 027 QUẢN LÍ DANH SÁCH BẰNG LIST 
## Tóm tắt 
- Hạn chế của mạng [] và lợi thế của `List<T>`

- Khai báo, khởi tạo c `List<T>` và `Add`, `Insert`, `Remove`, `RemoveAt`, `RemoveAll`, `Clear` 

- Tìm kiếm qua lọc bằng `Contains`, `IndexOf`, `Find`, `FindAll`

- Quản lí danh sách đối tượng bằng `List<Product>` và sắp xếp bằng `Sort`

## Hạn chế của mảng [] ? 
- Mảng cần phải biết trước kích thước và khó thêm bớt giữa chừng dễ dàng. Với dữ liệu có tính động thì bất tiện trong quản lí. 

- Đếm phần tử bằng `.Length`

--> *Mảng tĩnh*

## `List<T>` là gì?  
- `List<T>`cũng giống mảng tĩnh nhưng lại có tính linh hoạt. `<T>` như khuôn cho mọi kiểu mà vẫn an toàn kiểu type-safe, ví dụ: 

    `List<int>` chứa số nguyên

    `List<string>` chứa chuỗi

    `List<Product>` chứa các đối tượng Product 

    --> *mảng động* 

- Đếm phần tử bằng `.Count`

## Tổng kết/ Lưu ý
- Nếu `List<T>` có khả năng tự co giãn, vậy bên trong chứa gì? **Vẫn là mảng thôi**. Khi mình `Add` mà mảng nội bộ đầy thì `List` tạo mảng lớn thêm rồi coppy dữ liệu vào. 

- Hai khái niệm dễ nhầm: 
    - `count`: số phần tử thực sự đang có (thứ mình quan tâm hằng ngày)

    - `capacity`: số ô nhớ được cấp sẵn để chứ (chi tiết nội bộ, tối ưu hiệu năng) 

    --> hm, mỗi lần dữ liệu "phình ra" phải coppy toàn bộ... nếu vậy, nếu biết trước có rất nhiều phần tử, tại sẵn `new ;list<int>(1000)` để tránh cái list phình đi phình lại, chương trình phải xử lí lâu.

> Nếu vừa `foreach` một list vừa `add/removr` thì tuyệt... 
> C# ném ra lỗi `InvalidOperationException` vì bộ sưu tập (list) bị sửa đổi trong lúc duyệt 
> Muốn xóa trong lúc duyệt, thì `RemoveAll(cond)` hoặc duyệt trên bản sao. 

- Tóm tắt: 
```txt
                ┌─────────────────────────────┐
                │  List<T> (mảng co giãn)     │
                │  Bên trong: 1 mảng tự phình │
                └──────────────┬──────────────┘
                               │
     ┌────────────┬────────────┼───────────┬────────────┐
     v            v            v           v            v
   THÊM         XÓA         TRUY CẬP     TÌM/LỌC      SẮP XẾP
  - Add       - Remove     - list[i]   - Find        - Sort()
  - Insert    - RemoveAt   - .Count    - FindAll     - Sort(cmp)
  - AddRange  - RemoveAll              - Contains
              - Clear                  - IndexOf
```

## Lỗi "vô tri" đã phát giác
- **Vấn đề**: 
```csharp
List<string> names = new List<string> { "An", "Cuong", "Binh", "Thuy", "An", "Hung" };

List<string> tatCaA = names.FindAll(n => n.StartsWith("A"));

Console.WriteLine($"{tatcaA}");
```

**Kết quả**: Cái gì đây? Tui muốn in ra: An, An mà :(((
```txt
System.Collections.Generic.List`1[System.String]
``` 

- Muốn in cả `List<T>` ra màn hình: 

[x] không được dùng `Console.WriteLine(T)`

[v] Muốn bung dữ liệu trong cần: `string.Join(", ", names)` hoặc `foreach(...)`
```csharp
Console.WriteLine($"Tim tat ca, ten bat dau bang A: {string.Join(", ", tatcaA)}");  

// hoặc
foreach (string name in tatca)
{
    Console.WriteLine(name);
}

```

--> này không phải lỗi chương trình (Chương trình vẫn chạy bình thường `exit code 0`). **Lỗi trong cách yêu cầu C# hiển thị Collection**. 