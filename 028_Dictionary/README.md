# XÂY DỰNG TỪ ĐIỂN NGA - VIỆT
## Tóm tắt 
- `Dictionary<F, V>` = tập hợp các cặp khóa - giá trị, khóa duy nhất, tra cứu theo khóa siêu nhanh (O(1)).

- Khai báo và khởi tạo `Dictionary<TKey, TValue>`

- Thêm, xóa, sửa cặp khóa - giá trị

- Tra cứu an toàn bằng `ContainsKey` và `TryGetValue`

- Duyệt toàn bộ bằng `KeyValuePair`

- Hiểu vì sao Dictuonary tra cứu nhanh hơn List (cơ chế hàm băm)

- Xây một chương trình từ điển 

## Thuật toán 
- [1] Khai báo `Dictionary<string, string>` và danh sách từ vựng

- [2] Tra cứu an toàn bằng `ContainsKey` và `TryGetValue` 
    - Trực tiếp: `tuDien[key]: hoặc trả giá trị hoặc trả lỗi --> ngắn nhưng nguy hiểm, nếu khóa không có 

    - Gián tiếp: 
        + `ContainsKey` rồi `[]` kiểm tra `bool` trước: an toàn, dễ đọc nhưng tra 2 lần

        + `TryGetValue`: `bool` gán qua `out`: an toàn và chỉ tra 1 lần (nhanh nhất)

     `TryGetValue` tra cứu: nếu có khóa - trả `true`, gán nghĩa cho biến `out` nghia; nếu không thì trả `false` mà không ném lỗi (như `ContainsKey`). 

- [3] Duyệt toàn bộ từ điển  

    Muốn in cả cuốn từ điển: dùng `foreach` mỗi phần tử lấy ra là một `KeyValuePair` - một "cặp đôi" gồm `.Key` và `.Value` 

## Dictionary nhanh hơn List? 
```txt
   List tra "hello":       duyệt từng từ một -> xấu nhất N bước  (O(n))
   Dictionary tra "hello": tính thẳng "vị trí" từ khóa -> khoảng 1 bước  (O(1))

```
- Cơ chế hàm băm (hash function) (?). 
    - Khi đưa từ khóa `любезно` cho Dictionary --> chạy khóa --> qua công thức toán --> sinh ra mã băm (hash code): "ngăn tủ" chứa giá trị. 

    - Khi tra cứu, Dictionary tính lại mã băm --> nhảy đến ngăn chứa giá trị, không cần dò tuần tự

    - Hạn chế: Tốn nhiều bộ nhớ hơn `List`, cần chừa chỗ cho ngăn băm 

> Quy tắc chọn: Cần tra từ "khóa" (id, tên, mã số,...) -> dùng Dictionary
>               Cần truy cập chỉ số (index) hoặc duyệt tuần tự -> dùng List 

## Lưu ý
- Lỗi hiển thị tiếng Nga, cho trình biên dịch. 

> **Đầu vào**: 

```csharp
tuDien["надеяться"] = "hy vong";
``` 
> **Kết quả**: sao biên dịch lỗi :(((

```csharp
- ????????: hy vong
```

- **Khắc phục**: Bổ sung lệnh trước hàm in tại `Main`:

```csharp
Console.OutputEncoding = System.Text.Encoding.UTF8;
tuDien["надеяться"] = "hy vong";
``` 
---
[x] `Add` cùng cặp khóa 2 lần, ghi đè giá trị 

[v] `Add` với khóa trùng sẽ ném lỗi `ArgumentException`. Muốn ghi đè cần dùng `dict[key]` 
---
[x] Tra `dict[key]` với khóa không tồn tại thì trả về `null`

[v] Nó ném `KeyNotFoundException`, chương trình dừng. Dùng `TryGetValue` và `ContainsKey` sẽ an toàn hơn. 
---
[x] Dictionary giữ đúng thứ tự như List 

[v] Dictionary không đảm bảo thứ tự, tối ưu cho tra cứu nhanh
--- 
[x] Trong Dictionary khóa có thể trùng, giá trị thì cần khác. 

[v] Khóa phải là duy nhất, giá trị thì được quyền trùng. 

