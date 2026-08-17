# 033 ĐẾM SỐ TỪ FILE VĂN BẢN 
## Tóm tắt
- Đọc toàn bộ nội dung file bằng `File.ReadAllTexxt()` và kiểm tra bằng `File.Exists()`

- Tách chuỗi dài thành mảng bằng `Split()` với nhiều kí tự phân cách

- Lí do cần `StringSplitOptions.RemoveEmptyEntries` 

- Đếm số từ, số ký tự, số dòng trong file 

- Bọc code bằng `try-catch` để xử lí file chuyên nghiệp 

- Dùng `Dictionary` để thống kê tần suất xuất hiện 

## Lí thuyết
- [1] Đọc nội dung từ file
    - `File.ReadAllText()` đọc toàn bộ file vào RAM một lần.  

- [2] Xử lí chuỗi để tách từ 
    - `StringSplitOptions.RemoveEmptyEntries`: Khi văn bản có dấu cách liền nhau, hoặc dấu chấm theo sau là khoảng trắng (". "), `Slipt()` tạo những phần tử rỗng (""). 
    > Tùy chọn này quét sạch các phần tử rỗng đó, để không đếm “từ ma”. Bỏ nó đi là số từ sẽ phình lên một cách bí ẩn!

    - *Ý nghĩa các kí tự* 

| Kí tự | Ý nghĩa | Ví dụ |
|-------|---------|-------|
| `' '` | Khoảng trắng (space) | Ngăn cách phổ biến nhất | 
| `\t'` | Tab | Khi văn bản căn cột | 
| `'\n'`, `'\r'` | Xuống dòng | Hết một dòng | 
| `'.'`, `','`, `';'`, `':'` | Dấu câu | Cuối câu, liệt kê | 
| `'!'`, `'?'` | Dấu chấm than, dấu hỏi | Cuối câu | 

- [3] Dếm số lượng từ 

- **Nhưng** nếu file rỗng hoặc file không có quyền truy cập thì cần xử lí như nào? 
    - Bọc toàn bộ code bằng `try-catch` và thêm phần kiểm tra File rỗng bằng `if` 

    - Thứ tự `catch` cũng cần lưu ý: Các `catch` cụ thể (`UnauthorizedAccessException`, `IOException`) phải đứng trước `catch(Exception ex)` chung chung. Vì Exception là cha tất cả, nếu đặt nó lên đầu nó sẽ tóm tắt cả lỗi và catch cụ thể thể bên dưới không bao giờ được thực hiện. 

## Thuật toán 
- Xây dựng chương trình hoàn chỉnh có menu tương tác 
    - Chia nhỏ, tách logic riêng cho 2 phương thức `CountWordsInFile` và `GetSeparators` 

## Tổng kết/ Lưu ý
- Luôn `File.Exists()` trước khi đọc.

- Bọc thao tác file trong `try-catch`, hạn chế lỗi.

- Luôn dùng `StringSplitOptions.RemoveEmptyEntries` khi đếm từ - quét "từ ma".

- Chuẩn hóa chữ thường `(ToLower())` khi so sánh/đếm tần suất - “File” và “file” là cùng một từ.

- Gom ký tự phân cách vào một phương thức `(GetSeparators)` - sửa một nơi, dùng mọi nơi.

- Tách logic đọc file và xử lý dữ liệu thành các phương thức riêng - dễ test, dễ bảo trì.

- Kiểm tra `string.IsNullOrWhiteSpace()` cho nội dung file - tránh xử lý file rỗng.

- Mẹo nhớ: “Đọc - Cắt - Đếm” (Read - Split - Count). 
            
            Ba bước, ba động từ. 
            
            Và đừng quên “Cắt sạch rác” `(RemoveEmptyEntries)` giữa bước Cắt và Đếm!