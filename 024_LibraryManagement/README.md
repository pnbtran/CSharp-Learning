# 024 BÀI TẬP TỔNG HỢP: HỆ THỐNG QUẢN LÍ THƯ VIỆN ĐƠN GIẢN

## Tóm tắt
- Cần 3 lớp tương tác nhau: `book`, `member`, `library`

- Cho `menber` chứa `list<book>` chứ danh sách mượn riêng

- Viết logic trả và mượn 

- Dùng `List.Add`, `Remove`, `Contains`, `Find` để quản lí danh sách

## Thuật toán 
### Class tổng thể

| Class | Vai trò | Dữ liệu quản lí |
|-------|---------|-----------------|
| `book` | cuốn sách trên kệ | Mã sách, tác giả, trạng thái (có sẵn hay không) | 
| `member` | thành viên thư viện | mã thẻ, danh sách đang mượn | 
| `library` | quầy điều phối | toàn bộ danh sách chứa sách và thành viên | 

- Mỗi class chỉ lo đúng loại dữ liệu mà mình quản lí = phân chia trách nhiệm

### Cấu trúc
- [1] Class book 
     `public bool IsAvailable { get; set; } = true;` với phần `=true` là **giá trị mặc định của property**, khi không gán gì thì mặc định property là true. 

- [2] Class member
    - *Lưu ý 1*: `public List<Book> BorrowedBooks { get; private set; }` nghĩa là bên ngoài lớp đọc được sanh sách đang mượn nhưng không thể gán dè (sửa lung tung) 

    - *Lưu ý 2*: biến `BorrowBook` giúp cập nhật đồng thời: danh sách mượn đang quản lí `BorrowedBooks` và trạng thái sách `IsAvailable` 

- [3] Class Library + `Main` điều phối 

- Tóm tắt tương tác: 

```txt 
   Book   { IsAvailable = true;  DisplayInfo() }
              
              
              ^  (mượn/trả đổi IsAvailable)
              │
   Member { List<Book> BorrowedBooks (private set);
            BorrowBook(b): thêm b + b.IsAvailable=false
            ReturnBook(b): xóa b  + b.IsAvailable=true }
              ^
              │  (Library nắm giữ tất cả)
   Library{ List<Book> + List<Member>;
            AddBook / AddMember / FindBook(lambda) }
``` 

- Lý do cần cập nhật sách mượn và trạng thái sách *cùng lúc*? 
    - Nếu chỉ cập nhật trạng thái sách, không cập nhật người mượn --> đẩy thông báo sách đã cho mượn, không biết ai đang giữ. Sách biến mất bí ấn???

    - Nếu chỉ cập nhật người mượn (ví dụ An) nhưng không cập nhật trạng thái, sau đó Bình thực hiện lệnh mượn --> 1 quyển nhưng 2 người mượn? 

    - Nếu thực hiện riêng lẻ, thiếu quản lí --> ác mộng cho thủ thư quản lí

    - Vì vậy, cần thực hiện đồng thời để giảm rủi ro sai sót. Hoặc làm cả 2 hoặc không làm gì. 