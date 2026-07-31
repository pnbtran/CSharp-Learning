# Xây dựng Chương trình quản lí sinh viên
## Tóm tắt 
- Dùng mảng và biến đếm để lưu danh sách động. 
- Xây dựng menu lặp bằng `while + switch-case`. 
- Tách mỗi chức năng (thêm, xóa, tìm và xóa) thành phương thức riêng. 
- Tìm hiểu **CRUD** (Create - Read - Update - Delete) cơ bản. 

## Lưu đồ thuật toán
- Kiến trúc chương trình đơn giản: 
```txt
Program
│
├── Biến toàn cục (biến dùng chung cho cả chương trình)
│     ├── ListStudent
│     ├── CountStudent
│     └── CapacityStudent
├── Main()
├── ShowMenu()
├── DisplayMenu()
├── AddStudent()
├── DisplayStudents()
├── FindStudent()
└── DeleteStudent()
```

- **Luồng hoạt động**
```txt
                  Main              --> khởi tạo chương trình, 
                    │                   chuyển quyền cho menu
                    ▼
         Khởi tạo ListStudent[]     --> tạo mảng rỗng để lưu sv
                    │
                    ▼
                 ShowMenu()         --> Phân luồng thực hiện
                    │
            while(isRunning)        --> vòng lặp chính 
                    │
                    ▼
               DisplayMenu()        --> hiển thị KQ
                    │
                    ▼
              Người dùng nhập
                    │
                    ▼
                  switch            --> ra quyết định
      ┌─────────┬─────────┬─────────┬─────────┬
      ▼         ▼         ▼         ▼         ▼
 AddStudent  Display     Find     Delete     Exit  
             Students
      │         │         │         │
      └─────────┴─────────┴─────────┘
                    │
                    ▼
              Quay lại Menu         --> quay lại While
                                        false -> Kthúc
```

- Nhánh **"**AddStudent**
```txt
                ┌──────────────┐
                │ AddStudent() │
                └──────┬───────┘
                       │
                       ▼
              Danh sách đầy?
             Count >= Capacity
                │         │
             Có │         │ Không
                ▼         ▼
             Đã đầy   Nhập tên SV
           │              │
           │              ▼
           │      ListStudent[Count]
           │          = tên nhập
           │              │
           │              ▼
           │        CountStudent++
           │              │
           │              ▼
           │      "Đã thêm thành công"
           │              │
           └──────────────┘
                  │
                  ▼
             Quay về Menu
```

- Nhánh **DisplayStudent**
```txt
              ┌────────────────────┐
              │ DisplayStudents()  │
              └─────────┬──────────┘
                        │
                        ▼
               CountStudent == 0 ?
                  │           │
               Có │           │ Không
                  ▼           ▼
         "Danh sách rỗng"    i = 0
                  │           │
                  │           ▼
                  │     i < Count ?
                  │      │       │
                  │   Không     Có
                  │      │       │
                  │      ▼       ▼
                  │    Kết thúc  In List[i]
                  │               │
                  │               ▼
                  │             i++
                  │               │
                  └───────────────┘
```

- Nhánh **FindStudent**
```txt
                ┌───────────────┐
                │ FindStudent() │
                └──────┬────────┘
                       │
                       ▼
              Nhập tên cần tìm
                       │
                       ▼
                     i = 0
                       │
                       ▼
                 i < Count ?
                  │        │
               Không      Có
                  │        │
                  ▼        ▼
            "Ktìm thấy"   So sánh
                               │
                    List[i] == tên ?
                    │          │
                 Có │          │ Không
                    ▼          ▼
                In vị trí     i++
                tìm thấy  
                    │          │
                    └──────────┘
                           │
                           ▼
                      Kết thúc
```

- Nhánh **DeleteStudent**
```txt
               ┌─────────────────┐
               │ DeleteStudent() │
               └────────┬────────┘
                        │
                        ▼
                  Nhập tên cần xóa
                        │
                        ▼
                 Tìm vị trí cần xóa
                        │
              ┌─────────┴─────────┐
              ▼                   ▼
       Không tìm thấy        Tìm thấy
              │                   │
              ▼                   ▼
     "Không tìm thấy"      Dịch các phần tử
                              sang trái
                                  │
                                  ▼
                            CountStudent--
                                  │
                                  ▼
                          "Đã xóa thành công"
                                  │
                                  ▼
                              Quay về Menu
```

## Lưu ý
- Hạn chế của chương trình: kích thước mảng đang là cố định (`CapacityStudent = 100`), nếu xóa phần tử ở giữa phải đồn mảng thủ công --> mất thời gian nếu mảng có nhiều giá trị. 

- **Hiểu lầm đã dính**

| Sai | Đúng |
|-----|------|
| `switch` không cần `break` mỗi `case` | Bắt buộc `break` -> thiếu là lỗi |
| `default` trong `switch` không nhiều tác dụng | `default` chức năng gần `else`( của if) dùng để xử lí giá trị không khớp |
| Dùng `switch` thay `if-else` | không thể, `switch` chỉ tối ưu phần tử rời rạc, điều kiện/khoản giá trị/ biểu thức vẫn cần `if - else` |

- **Lưu ý**
    - Mỗi tính năng chỉ có một phương thức thực hiện -> CRUD = thêm/xem/tìm/xóa.  
    - `switch` cho menu (nhớ break + default).
