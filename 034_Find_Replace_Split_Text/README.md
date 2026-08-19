# XỬ LÍ FILE VÀ CHUỖI - TÌM, THAY THẾ VÀ CHIA TÁCH CHUỖI 

## Tóm tắt
- Tìm chuỗi con với `Contains(), IndexOf(), LastIndexOf(), StartsWith(), EndsWith()`

- Thay thế nội dung bằng `Replace()` (cả kí tự lẫn chuỗi)

- Chia tách chuỗi thành mảng với `Split()` và nhiều kí tự phân tách

- Trích dẫn đoạn văn con bằng `Substring()`

- Dùng `StringComparison.OrdinalIgnoreCase` để so sánh và không phân biệt hoa thường 

- Kết hợp nhiều phương thức để chuẩn hóa dữ liệu (email, CSV) 

## Thuật toán
- Phương thức`Contains()` trả kết quả: `True/ False` 

- Phương thức `IndexOf()` và `LastIndexOf()`, chỉ vào vị trí nếu không thấy sẽ trả về `-1` 

- Phương thức `StartsWith()` và `EndsWith()`, kiểm tra phần dấu phẩy và phần đuôi của chuỗi (tiện lợi cho file `.txt, .docx`) 

Bảng tổng hợp phương thức: 

| Phương thức | Trả về | Dùng khi nào | 
|-------------|--------|--------------|
| `Contains()` | `bool` | Chỉ cần biết có/không | 
| `IndexOf()` | `int` (vị trí hoặc `-1`) | Cần vị trí xuất hiện đầu tiên | 
| `LastIndexOf()` | `int` (vị trí hoặc `-1`) | Cần vị trí xuất hiện cuối cùng |
| `StartsWith()` | `bool` | Xét phần đầu chuỗi | 
| `EndsWith()` | `bool` | Xét phần cuối chuỗi | 

- Thay thế trong chuỗi 
    - Phương thức `Replace`: cho phép thay toàn bộ các lần xuất hiện. Phương thức này nhận `char` lẫn `string` 

    - Tìm kiếm thay thế = `Contains()` + `Replace()` 

- Chia tách chuỗi 
    - Dùng `Split()` chia chuỗi thành `String[]` dựa trên kí tự và phân cách 
    > `StringSplitOptions.RemoveEmptyEntries` loại bỏ phần tử rỗng hai có 2 dấu phân cách dính nhau. 

    - Xử lí CSV (Comma-Sepaarated Values) là định dạng dữ liệu bảng đơn giản nhất --> xử lí bằng `Split()` 

    - `Substring()` dùng cắt đoạn con
        - `chuoi.Substring(start)` cắt từ vị trí start đến hết chuỗi

        - `chuoi.Substring(start, length)` lất `length` lí tự từ `start`

- Thử thực hiện chuỗi phương thức: trim -> trplace -> split -> chuẩn hóa và lọc trùng 
    - `Distinct()` đến từ LINQ để lọc trùng 


## Tổng kết/ Lưu ý 
**Hiểu lầm cần tránh** 
- [ Sai ] `Replace()` chỉ đổi **lần đầu** xuất hiện 
- [ Đúng ] `Replace()` đổi **tất cả** các lần xuất hiện. Muốn đổi có điều kiện có thể dùng Regex

- [ Sai ] Gọi `chuoi.ToUpper()` là chuỗi tự động in hoa
- [ Đúng ] Chuỗi bất biến nên cần gán lại `chuoi = chuoi.ToUpper();`

- [ Sai ] Dùng `IndexOf()` rồi `Substring(viTri)` mà không kiểm tra `-1`
- [ Đúng ] Luôn luôn `if (viTri >= 0)` vì nếu KQ ném `-1` thì `Súntring()` sẽ ném ra lỗi ngoại lệ 

- [ Sai ] So sánh `chuoi1.ToLower() == chuoi2.ToLower()` để bỏ qua viết hoa và thường
- [ Đúng ] `chuoi1.Equals(chuoi2, StringComparison.OrdinalIgnoreCase)` nhanh hơn và không cần tạo chuỗi tạm 

**Tóm tắt** 

```txt
                 CHUỖI VĂN BẢN (string - bất biến)
                            │
        ┌───────────────────┼───────────────────┐
        ▼                   ▼                   ▼
     TÌM KIẾM            THAY THẾ            CHIA TÁCH
   Contains()           Replace()            Split()  ─► string[]
   IndexOf()                                 Substring() ─► đoạn con
   LastIndexOf()
   StartsWith()
   EndsWith()
        │                   │                   │
        └──────► luôn TRẢ VỀ CHUỖI/MẢNG MỚI ◄────┘
                 (phải gán lại để giữ kết quả)
```

- *Trong đó*:
    - `Contains()`: có chứa chuỗi con không? (T/F)

    - `IndexOf()/ LastIndexOf()`: Vị trí xuất hiện đầu/ cuói, trả lại `-1` nếu không có 

    - `StartsWith()/ EndsWith()`: xét phần đầu/ phần cuối chuỗi

    - `Replace()`: đổi tất cả lần xuất hiện

    - `Split()`: cắt mảng thành chuỗi theo dấu cách

    - `Substring()`: lấy đoạn con theo yêu cầu

    - Immutable: chuỗi bất biến - thao tác sinh chuỗi con (mọi thao tác đều trả về chuỗi mới nên cần gán lại, cần dùng `StringSplitOptions.RemoveEmptyEntries` để bỏ qua kí tự hoa-thường và `StringBuilder` khi cần sửa chuỗi nhiều lần)