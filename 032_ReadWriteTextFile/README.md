# 032 ĐỌC VÀ GHI FILE TẼT ĐƯƠN GIẢN 
## Tóm tắt
- Lí do cần đọc/ ghi file và khi nào dùng

- Dùng namepage `System.IO` và lớp file để thao tác

- Đọc file bằng `ReadAllText`, `ReadAllLine`, `ReadLines` 

- Kiểm tra file tồn tại với `file.Exists()` và xử lí ngoại lệ bằng try-catch 

- Xử lí encoding UTF-8 để tiếng Việt không lỗi font 

## Lý thuyết
### Lí do cần đọc/ ghi file 
- File text dùng để lưu trữ dữ liệu phổ biến. Cách đọc và ghi file cho phép chương trình: 
    - Lưu trữ dữ liệu lâu dài (không mất khi tắt chương trình) 

    - Trao đổi dữ liệu giữa các chương trình khác nhau

    - Đọc cấu hình hoặc dữ liệu đầu vào từ bên ngoài 

### Các lớp cơ bản để làm việc với file 
- `System.IO Namespage` 
    - Khai báo thư viện dữ liệu `using System.IO` 

- **Lớp File** 
    - Cung cấp phương thức tĩnh (static) để thao tác 

    - Như `ReadAllText, WriteAllText` tự mở file, làm việc, đóng file 

## Thuật toán
- [1] Đọc toàn bộ file
    - Phương thức `ReadAllText()` đọc toàn bộ nội dung file vào một chuỗi string 

- [2] Đọc từng dòng file 
    - Phương thức `ReadAllLines()` đọc file và trả về mảng các dòng 

    - Cần cẩn trọng: `ReadAllText` và `ReadAllLine` nạp toàn bộ file vào bộ nhớ. Nếu file vài trăm MB thì chương trình có thể lag... lúc này cần ưu tiên `ReadLine()` 

| Phương thức đọc | Trả về | Khi nào dùng | 
|-----------------|--------|--------------|
| `File.ReadAllText()` | `string` (cả file) | File nhỏ, cần nguyên văn bản | 
| `File.ReadAllLine()` | `string[]` (mảng dòng) | Cần xử lí từng dòng, biết tổng số từng dòng | 
| `File.ReadLines()` | `IEnumerable<string>` | File lớn, đọc lười (lazy) tiết kiệm RAM | 

- [3] Ghi file text
    - Ghi toàn bộ nội dung 
        - Phương thức `WriteAllText()` ghi toàn bộ nội dung vào file. 
        
        - Nếu file đã tồn tại, nó sẽ bị ghi đè, xét trang cũ, viết lại trang mới

    - Ghi từng dòng 
        - Phương thức `WriteAllLines()` ghi mảng các chuỗi vào file, mỗi phần tử là một dòng. 

    - Thêm nội dung vào file có sẵn
        - Phương thức `AppendAllText()` và `AppendAllLines()` thêm nội dung vào cuối file mà không xóa nội dung cũ.

        - `Write` = ghi đè (xóa hết cái cũ), `Append` = ghi thêm (giữ cái cũ) 


- Chương trình: Quản lí danh sách công việc 
    - Xây dựng ứng dụng quản lí To-do-list 
    
    - Dùng `AppendAllText`: ghi thêm

    - `WriteAllText(FileName, string.Empty)`: ghi dè bằng chuỗi rỗng, để xóa  

- Nếu tiếng việt bị lỗi font, dùng: 
```csharp
// Sử dụng UTF-8 để hỗ trợ tiếng Việt
File.WriteAllText("file.txt", "Xin chào Việt Nam", Encoding.UTF8);
``` 
## Tóm tắt
```txt
                  ┌─────────────────────────┐
                  │      System.IO.File     │
                  └────────────┬────────────┘
                               │
          ┌────────────────────┼─────────────────────┐
          ▼                    ▼                     ▼
     ĐỌC (Read)          GHI ĐÈ (Write)        GHI THÊM (Append)
   ┌──────────────┐    ┌──────────────┐      ┌──────────────────┐
   │ ReadAllText  │    │ WriteAllText │      │ AppendAllText    │
   │ ReadAllLines │    │ WriteAllLines│      │ AppendAllLines   │
   │ ReadLines    │    └──────────────┘      └──────────────────┘
   └──────────────┘
          │
          ▼
   File.Exists() ──► try { ... } catch (IOException) { ... }
```