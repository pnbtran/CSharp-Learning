# 035 LƯU DANH SÁCH ĐỐI TƯỢNG VÀO FILE JSON 

## Tóm tắt
- Tạo class object để chứa dữ liệu 

- Tạo và quản lí `List<T>` chứa nhiều object 

- Dùng `System.Text.Json` để `Serialize` danh sách thành chuỗi JSON 

- Ghi đè chuỗi JSON xuống file bằng `File.WriteAllText`

- Đọc file JSON và `Deserialize` ngược thành `List<object>` 

- Xử lí ngoại lệ (file không tồn tại, JSON hỏng) 

## Thuật toán 
- [1] Tạo class chứa mẫu 
    - Tạo **constructor mặc định** `public Student() {}` - không tham số. 

    - Mọi thuộc tính đều có `{get; set;}`

    - Lý do: `System.Text.Json` cần constructor rỗng + phương thức công khai để đổ dữ liệu vào khi `Deserialize`. Nếu thiếu, việc đọc JSON sẽ lỗi 

- [2] Tạo danh sách đối tượng 

- [3] Lưu danh sách vào file JSON 
    - Thêm namespace cần thiết 
    ```csharp 
        using System.Text.Json;
        using System.IO;
    ```

    - Viết phương thức lưu dữ liệu JSON 
        - Tùy chọn `WriteIndented = true` - dùng để canh lề cho file JSON  

        - `JsonSerializer.Serialize(danh sach, options)` - biến object/list -> chuỗi JSON

        - `JsonSerializerOptions{WriteIndented = true}` - định dạng đẹp, dễ đọc 

        - `File.WriteAllText(filePath, jsonString)` - ghi chuỗi xuống file (ghi đè nếu đã có)  

        ```csharp
            static void SaveListStudent(List<Student> ListStudent, string filePath)
            {
                try
                {
                    // Tạo các tùy chọn để format JSON 
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };

                    // Chuyển danh sách thành chuỗi JSON
                    string jsonString = JsonSerializer.Serialize(ListStudent, options);

                    // Ghi chuỗi JSON vào file
                    File.WriteAllText(filePath, jsonString);

                    Console.WriteLine($"Da luu danh sach sinh vien vào file: {filePath}");
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Loi khi luu file: {ex.Message}");
                }
            }
        ``` 

    - Đọc dữ liệu từ file JSON 
        - Toán tử `??` ở dòng ``return ListStudent ?? new List<Student>();` lí do:  
            + Nếu `listStudent` khác `null` thì trả nó về

            + Nếu `listStudent` là `null` thì trả về list rỗng 

            --> giúp method luôn trả về `List<Student>` thay vì trả về `null`

            ```txt
                    ListStudent != null
                        → return ListStudent

                    ListStudent == null
                        → return new List<Student>()
            ```

        ```csharp
            public static List<Student> ReadListStudent(string filePath)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        Console.WriteLine($"File {filePath} khong ton tai");
                        return new List<Student>();
                    }

                    string jsonString = File.ReadAllText(filePath);

                    List<Student> ListStudent =JsonSerializer.Deserialize<List<Student>>(jsonString);

                    Console.WriteLine($"Da doc danh sach sinh vien tu file: {filePath}");
                    return ListStudent ?? new List<Student>();
                }

                catch (Exception ex)
                {
                    Console.WriteLine($"Loi khi doc file: {ex.Message}");
                    return new List<Student>();
                }
            }
        ``` 

## Tổng kết/ Lưu ý 

- **[Sai]**: “Cứ `Deserialize` là dùng được ngay, không cần kiểm tra

- **[Đúng]**: Kết quả `Deserialize` có thể là `null` (nếu file chứa “null” hoặc rỗng). Luôn kiểm tra `?? new List<SinhVien>()` hoặc `if (ds == null)` trước khi `foreach`.

------

- **[Sai]**: `File.WriteAllText` sẽ nối thêm vào file cũ

- **[Đúng]**: `File.WriteAllText` sẽ GHI ĐÈ toàn bộ file. Nếu muốn giữ lại dữ liệu file cũ, phải đọc lên, thêm vào list rồi ghi lại cả list

------

- **[Sai]**: Class nào cũng Deserialize được, không cần constructor rỗng

- **[Đúng]**: `System.Text,Json` cần constructor rỗng + `public` + `get; set` để đỗ dữ liệu 

------

- **[Sai]**: Tên Json viết kiểu nào cũng được

- **[Đúng]**: Cần phân biệt hoa và thường. Khác kiểu chữ thì property nhận `null`

- Cấu trúc hiện tại của chương trình 

    ```txt 
    Program
    │
    ├── Student
    │   ├── properties
    │   ├── constructor
    │   └── ShowInfo()
    │
    ├── SaveListStudent()
    ├── ReadListStudent()
    ├── CheckFile()
    ├── ReadStudentListSave()
    └── Main()
    ```

- Luồng xử lí hiện tại 
    ```txt
    Tạo List<Student> 
        ↓
    Hiển thị dữ liệu ban đầu
        ↓
    SaveListStudent()
        ↓
    students.json
        ↓
    CheckFile()
        ↓
    ReadStudentListSave()
        ↓
    Deserialize JSON
        ↓
    List<Student>
        ↓
    foreach
        ↓
    ShowInfo()
    ```

- Nếu property dạng `private` hoặc thiếu `set`, `system.Text.Json` --> mặc định không đổ file vào được khi đọc. **Giải pháp**: cần đảm bảo property luôn `public` và `{get; set;}`

## Lỗi "vô tri" đã phát giác
### Sai logic, đặt loạn vị trí 
- **Code đang lỗi**
  
        ```csharp
        List<Student> ListStudent = new List<Student>();
        CheckFile(filePath);
        ReadStudentListSave(filePath);

        // ListStudent.Add

        string filePath = "students.json";
        ```

- **Comliper**: `filePath` của tui đây bà???
  
        ```txt
        Main()
        ↓
        filePath ???       ← chưa tồn tại
        ↓
        CheckFile(filePath)
        ReadStudentListSave(filePath)
        ↓
        string filePath = "students.json"  ← tới đây mới khai báo
        ``` 

- **Cách sửa lại** - đổi vị trí lại
  
    ```csharp
    List<Student> ListStudent = new List<Student>();
    
    // ListStudent.Add

    string filePath = "students.json";
    CheckFile(filePath);
    ReadStudentListSave(filePath);
    ```
