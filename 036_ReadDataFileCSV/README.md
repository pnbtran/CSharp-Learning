# 036 ĐỌC XỬ LÍ DỮ LIỆU FILE CSV

## Tóm tắt
### Nội dung học được
- Hiểu cấu trúc của file CSV

- Đọc file CSV bằng `File.ReadAllLines()` và `StreamReader`

- Dùng `TextFiTextFieldParser` để xử lí file CSV "khó tính" 

- Chuyển dữ liệu CSV thành danh sách object dạng `List<T>`

- Xử lý lỗi khi file còn thiếu, hỏng, dữ liệu sai định dạng

### Giải thích lý thuyết
- File CSV (Comma-Separated Values): file dữ liệu văn bản thuần: mỗi dòng là một bảng ghi và các ô dữ liệu được ngăn nhau bằng dấu phẩy. 

- Lý do File CSV phổ biến: 
    - Dễ đọc, dễ chỉnh sửa bằng trình soạn thảo thông thường

    - Được hỗ trợ bởi nhiều ứng dụng Excel, Google Sheets

    - Nhẹ và dễ chia sẻ

- Vậy File CSV và File JSON khác nhau như nào? 

| Tiêu chí | CSV | JSON |
|----------|-----|------|
| Cấu trúc | Phẳng (hàng, cột) | Phức tạp (lồng nhau, nhiều tầng) | 
| Kích thước | Nhẹ | Nặng hơn (nhiều lớp kí tự `{}` và `:` )
| Mở bằng Excel | Trực tiếp | Không tiện | 
| Dữ liệu phức tạp | Khó diễn tả | Rất tốt | 

> Vì vậy, nếu dữ liệu dạng bảng đơn giản - dùng CSV
> Dữ liệu là các object lồng nhau thì dùng JSON 

## Thuật toán 
### Phương pháp 1: Sử dụng `StreamReader`
- **Đọc toàn bộ file**
    - `StreamReader` hỗ trợ đọc file từng dòng và từ trên xuống dưới 

    - `File.ReadAllLines()` đọc nguyên file và trả về `string[]`

- **Phân tích cột**
    - Dữ liệu được xử lý tách bằng `line.Split(',')` - chịu trách nhiệm cắt mảng của trường data 

    - Dùng `string.IsNullOrWhiteSpace(line)` để bỏ qua dòng trống - file CSV ngoài thường có dòng trống cuối, nếu không lọc sẽ bị lỗi "index out of range" 

### Phương pháp 2 - Sử dụng TextFielParser
- `TextFielParser` cho phép xử lí CSV mạnh mẽ hơn khi dữ liệu chứa dấy phẩy trong giá trị 
    - Ví dụ như dữ liệu tính, định dạng phân số bằng dấu phẩy `1,15` nếu tách bằng `Split(',')` thô thì sẽ cắt sai

    - `TextFielParser` hiểu quy ước nháy kép nên xử lí đúng

### So sánh 2 cách đọc dữ liệu `Split(',')` và `TextFielParser`

| --- | `Split(',')` | `TextFielParser` | 
|-----|--------------|------------------|
| Tốc độ để code | Nhanh, gọn | DàiDài, khó | 
| Mức độ phức tạp | Dễ đọc, dễ hiểu | Phức tạp hơn, dễ bị nhầm giá trị | 
| Dấu phẩy trong giá trị | Dễ bị cắt sai | Xử lí đúng | 
| Phù hợp | File đơn giản, tự kiểm soát | File "thật" dữ liệu phức tạp | 

- Nguyên nhân "gây lú" khi xử lí CSV 
    - Không phải cứ `'` là biết nó đang làm gì, cần phải quy ước format delimited của file từ trước

    - Output đang dùng trong bài: 

    ```txt
    Phương pháp 1 
        → Rbt = 1.15 MPa → dấu "," - chia cột và "." - cho phần thập phân

    Phương pháp 2 
        → Rbt = 1,15 MPa → dấu ";" - chia cột và "," - cho phần thập phân
    ```

    **→ 2 cách parser đang đọc cùng giá trị nhưng khác cách biểu diễn**

    - *Đặc biệt quan trọng*: Định dạng dữ liệu phải thống nhất giữa file và parser.

> Đối với file CSV tự tạo, có thể kiểm soát format từ đầu -> ưu tiên chọn `Split(',')`
> Đối với file CSV xuất từ Excel/hệ thống, khó kiểm soát format -> ưu tiên chọn `TextFielParser` 

### Phương pháp 3 - Tạo lớp đối tượng đọc dữ liệu 
- Thay vì, đọc dữ liệu rời dạng `string[]` kiểu `values[0], values[1],...`, chúng ta có thể dùng OOP để gom dữ liệu thành object rõ ràng

    - Định nghĩa `Class Input`

    - Đọc CSV và chuyển danh sách đối tượng 

- Luồng tính toán: Đọc CSV -> Tạo List<InputData> -> Kiểm tra dữ liệu -> Tạo Section 
-> Gán Method tính cho Section -> In kết quả 

    ```txt 
            Data1.csv
        ↓
        filePath3 = filePath1
        ↓
        ReadInputDataFromCSV(filePath3)
        ↓
        File.ReadAllLines()
        ↓
        Split(',')
        ↓
        parse từng dòng
        ↓
        InputData
        ↓
        List<InputData>
        ↓
        IsValid()
        ↓
        CreateSection(inputDataList)
        ↓
        Section
        ↓
        mapping:
        Lw, tw, hw, Br, a, Rb, Rs...
        ↓
        các method tính toán
        ├── GetAreaWall()
        ├── GetAreaPier()
        ├── SlendernessRatio()
        ├── SteelPercentage()
        └── SteelPercentageMax()
        ↓
        in kết quả
    ``` 

- Kết quả tính: 

    ```txt
    Aw = 2.40 m²
    Ar = 0.60 m²
    L0/Hw = 1.03
    μ-req = 0.69 %
    μ-max = 3.81 %
    ```

## Tổng kết/ Lưu ý 
### So sánh 3 phương pháp - 3 mức độ trừu tượng để đọc file CSV
- [1] `ReadAllLines` / `StreamReader`: Làm sao để đọc CSV? 

- [2] `TextFieldParser`: Làm sao phân tích CSV?

- [3] `OOP`: Làm sao biến dữ liệu CSV thành dữ liệu có ý nghĩa cho chương trình? 

- **Tóm tắt** 
    ```txt
    CSV
    │
    ├── Cách 1: đọc thô
    │     File.ReadAllLines() / StreamReader
    │     → string
    │     → string[]
    │
    ├── Cách 2: parser CSV
    │     TextFieldParser
    │     → hiểu delimiter / field
    │     → string[]
    │
    └── Cách 3: OOP
        CSV
        ↓
        Parse
        ↓
        DataInput object
        ↓
        List<DataInput>
    ```

- CSV thô → StreamReader → TextFieldParser → OOP → InputData → List<InputData> → mapping → Section → method tính toán → output.

## Lỗi "vô tri" đã phát giác

- **Tóm tắt** chuỗi vật lộn `0 → NaN → ∞ → 260 đâu rồi → à Rs đây → chạy đúng`

| № | Lỗi | Toai đã làm gì? | Nguyên nhân | 
|---|-----|-----------------|-------------|
| 1 | `Microsoft.VisualBasic.FileIOFileIO` không nhận | Xóa nốt namespace | `File.ReadAllLines()` thực ra thuộc `System.IOIO` |
| 2 | `TextFieldParser` không tồn tại | Không hiểu lí do | Chưa reference `Microsoft.VisualBasic` | 
| 3 | `FieldType` không tồn tại | Dùng sai tên | Nhầm API | 
| 4 | KQ mất phần thập phân (trả về 1 thay gì 1,15) | Tưởng parser tính sai | `,` vừa là delimiter vừa là decimal separator | 
| 5 | `string[]` gán vào `List<InputData>` | Viết `List<InputData> = File.ReadAllLines()` | `ReadAllLines()` trả `string[],` chưa parse object |
| 6 | `foreach (InputData x in InputData)` | Dùng tên class ở bên phải in | `InputData` là type, không phải collection |
| 7 | Gọi `InputData.CreateSection()` | Method lại nằm trong `Section` | Gọi sai class | 
| 8 | ShowInfo(filePath3) | truyền đường dẫn vào method | `ShowInfo()` không nhận tham số và là instance method | 
| 9 | `Lw/tw/hw` không vào `Section` | VD: file CSV ghi tw, nhưng đặt tên property Tw| File CSV và tnn property không khớp |  
| 10 | Kết quả `μreq = 0` | Tưởng tính sai | CSV không có As nên As mặc định = 0 |


- Khi làm việc file CSV cần nhớ: 
    - Delimiter là gì? 
    - Key mapping là gì? đi đâu? 
    - Kiểu dữ liệu gì? 
    - Object nào chịu trách nhiệm tính toán? 