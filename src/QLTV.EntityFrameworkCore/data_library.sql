delete from Library.AppCategories
delete from Library.AppAuthors
delete from Library.AppBlocks
delete from Library.AppBooks
delete from Library.AppBorrows
delete from Library.AppReaders

------------------------------------AppCategories
insert into Library.AppCategories(Id, NameCategory, DescriptionCategory, ExtraProperties, ConcurrencyStamp, CreationTime, CreatorId, IsDeleted)
values 
--1
('406a450b-5121-4156-858e-76c195a85392', N'Giáo trình', N'Giáo trình là hệ thống chương trình giảng dạy của một môn học. Nó là tài liệu học tập hoặc giảng dạy được thiết kế và 
biên soạn dựa trên cơ sở chương trình môn học', '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)),
DATEADD(Day, -5, GETDATE()), NEWID(), 0),
--2
('09faf44c-84f4-42ce-bd7f-1626326c1bde', N'Tiểu thuyết', N'Tiểu thuyết là một thể loại văn xuôi có hư cấu, thông qua nhân vật, hoàn cảnh, sự việc để phản ánh bức tranh xã hội 
rộng lớn và những vấn đề của cuộc sống con người, biểu hiện tính chất tường thuật, tính chất kể chuyện bằng ngôn ngữ văn xuôi theo những chủ đề xác định.', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--3
('6b09075e-5a34-4e17-90c5-fc3fb813bfe6', N'Tâm lý', N'Sách tâm lý học được hiểu là những cuốn sách nghiên cứu, phân tích về các hiện tượng tâm lý hoặc tinh thần nảy sinh trong não người', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--4
('338e7721-cc71-4515-b82c-1c7f903392f7', N'Tự lực', N'Sách tự lực là sách nhằm giúp bạn đạt được những thành công nhờ chính bản thân mình', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--5
('c4cb8023-ebd6-4fd3-9ca3-1c95d996e0d5', N'Văn học', N'Sách văn học là loại hình sáng tác đặc biệt tái hiện lại những bình diện của cuộc sống, của xã hội và con người dưới ngòi bút trào phúng và văn hoa', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--6
('0a1c4094-da55-4775-b803-5b77f08b39a1', N'Khoa học', N'Sách khoa học là sách nói về những khám phá quan trọng bậc nhất của loài người ở nhiều lĩnh vực như: thiên văn học, vũ trụ học, di truyền học,..', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--7
('52cbfd6f-b33c-43a3-8380-83d3f5a2e560', N'Xã hội học', N'Sách xã hội học là sách khoa học nghiên cứu về xã hội và hệ thống các mối quan hệ xã hội của con người.', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--8
('2157028b-7c97-4700-bb83-70d1f1fd4e33', N'Y học', N'Sách y học là sách nói về các nghiên cứu về ý học, bệnh học và vấn đề sinh lý của con người', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0)

------------------------------------AppAuthors
insert into Library.AppAuthors(Id, NameAuthor, DateOfBirth, DescriptionAuthor, ExtraProperties, ConcurrencyStamp, CreationTime, CreatorId, IsDeleted)
values
--1
('ec59a588-4b5b-4c1f-a3b1-c738fc4a6ea1', N'Đỗ Nguyên Sơn', '1961-05-05', N'Hiện tại là trưởng Khoa Toán - Đại học Đà Lạt', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--2
('ea0642c5-1070-400e-be8b-6f1675a023bf', N'David J. Lieberman', '1953-10-15', N'Ông là một tiến sĩ đồng thời là bác sĩ tâm lý và tác giả chuyên xuất bản các cuốn sách thuộc thể loại tâm lý
hành vi con người.', '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--3
('da39a999-e9b9-4d9d-8f19-950627327cee', N'Robin Sharma', '1964-06-16', N'Robin Sharma là nhà văn người Canada, nổi tiếng với bộ sách The Monk Who Sold His Ferrari', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--4
('247d26c1-39f6-45ce-a694-9c73c06d1a9e', N'Dale Carnegie', '1888-11-24', N'Dale Breckenridge Carnegie là một nhà văn và nhà thuyết trình Mỹ và là người phát triển các lớp tự giáo dục, nghệ thuật bán hàng, huấn luyện đoàn thể, nói trước công chúng và các kỹ năng giao tiếp giữa mọi người','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--5
('d553ac37-400c-4ee6-81ba-9e11024eaf0b', N'Stephen Covey', '1932-10-24', N'Stephen Richards Covey là một nhà giáo dục, một tác giả, một doanh nhân, và một nhà diễn giả người Mỹ', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--6
('a19f5ed1-f058-42b4-89d4-a702778b9027', N'Phùng Quán', '1932-1-24', N'Phùng Quán là một nhà văn, nhà thơ Việt Nam, bắt đầu viết trong khoảng thời gian của cuộc chiến tranh Đông Dương và khẳng định được văn tài với Vượt Côn Đảo nhưng ông được biết đến nhiều hơn sau Đổi mới','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--7
('daeff859-80a1-4b36-8c23-aacd6490f436', N'Harper Lee', '1926-04-28', N'Nelle Harper Lee, thường được biết tới với tên Harper Lee, là một nữ nhà văn người Mỹ. Bà được biết tới nhiều nhất qua tiểu thuyết đầu tay Giết con chim nhại', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--8
('ad09b7c8-6f35-4210-9a1e-af9a04ae9704', N'Lev Nikolayevich Tolstoy', '1828-09-09', N'Bá tước Lev Nikolayevich Tolstoy là một tiểu thuyết gia người Nga, nhà triết học, người theo chủ nghĩa hoà bình','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--9
('40b9a0f4-64c5-4711-ae23-cc488165098c', N'Bill Bryson', '1951-12-08', N'William McGuire Bryson OBE HonFRS là một tác giả người Mỹ gốc Anh của các cuốn sách về du lịch, ngôn ngữ tiếng Anh, khoa học và các chủ đề phi hư cấu khác','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--10
('e4ce70e9-ad2d-4341-936b-e68e58edf769', N'Einstein', '1879-03-14', N'Albert Einstein là một nhà vật lý lý thuyết người Đức, được công nhận là một trong những nhà vật lý vĩ đại nhất mọi thời đại, người đã phát triển thuyết tương đối tổng quát, một trong hai trụ cột của vật lý hiện đại', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--11
('d00fbe2d-ec1d-4dda-a9be-f29a4ae1751a', N'Pranab Mukherjee', '1935-12-11', N'Kumar Pranab Mukherjee là Tổng thống thứ 13 của Ấn Độ. Mukherjee là một nhà lãnh đạo cấp cao của Đảng Quốc Đại Ấn Độ cho đến khi ông từ chức khỏi chức vụ chính trị này trước cuộc bầu cử tổng thống của mình vào ngày 22 tháng 7 năm 2012','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--12
('304e2678-5ed8-41ec-8e4c-05b9a9c1d626', N'Emile Durkheim', '1858-04-15', N'Émile Durkheim là một nhà xã hội học người Pháp nổi tiếng, người đặt nền móng xây dựng chủ nghĩa chức năng và chủ nghĩa cơ cấu; người đã góp công lớn trong sự hình thành bộ môn xã hội học và nhân chủng học', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--13
('d0df0f13-66be-441b-b664-088b5c0f60f9', N'Peter L. Berger', '1929-03-17', N'Peter Ludwig Berger là một nhà xã hội học người Mỹ gốc Áo và nhà thần học Tin lành','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--14
('063cf781-ebbf-456c-84e9-0c4056120e62', N'Ajahn Chah', '1978-06-17', N'Ajahn Chah là một cao tăng Phật giáo người Thái Lan, thuộc dòng tu khổ hạnh trong rừng của Thượng tọa bộ', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--15
('361b0ad5-9257-412c-88bb-21f5c7cd4c45', N'Phạm Đình Lựu', '1935-10-06', N'GS Phạm Đình Lựu, chủ nhiệm Bộ môn Sinh lý học ĐH YK Phạm Ngọc Thạch','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--16
('023745ac-c028-4864-978d-358d6929a0be', N'Frank H. Netter', '1906-04-25', N'Frank Henry Netter là một bác sĩ phẫu thuật và họa sĩ minh họa y khoa người Mỹ', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--17
('706e498b-d51f-486a-83ec-395a1866460f', N'Nguyễn Quốc Anh', '1959-09-01', N'Ông là giám đốc Bệnh viện Bạch Mai','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--18
('b256ea41-ebe6-411c-9a5d-3df624f31481', N'N. Gregory Mankiw', '1958-02-03', N'Nicolas Gregory Mankiw là một nhà kinh tế học người Mỹ. Ông được bình chọn là một trong 20 nhà kinh tế học xuất sắc nhất thế giới hiện nay', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--19
('d8452122-a067-4fce-a025-43d692f615f6', N'PGS TS Phan Thị Cúc', '1978-11-24', N'Bà là trưởng khoa Tài chính ngân hàng Trường ĐH Công nghiệp TP.HCM','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--20
('7e23acc8-53e2-415f-93c8-5e1ec853135b', N'Dan Ariely', '1967-04-29', N'Dan Ariely là một giáo sư và tác giả người Mỹ gốc Israel. Ông là Giáo sư tâm lý học và kinh tế học hành vi James B. Duke tại Đại học Duke', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--21
('a75997ff-f8d1-4c6e-bf1d-67c8295913b7', N'Daniel Gilbert', '1957-11-05', N'Daniel Todd Gilbert là một nhà tâm lý học và nhà văn xã hội người Mỹ. Ông là giáo sư tâm lý học Edgar Pierce tại Đại học Harvard và được biết đến với nghiên cứu của ông với Timothy','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--22
('e19efb1c-61f0-44f3-8889-ac1d8d3b0f00', N'Paulo Coelho', '1947-08-24', N'Paulo Coelho là tiểu thuyết gia nổi tiếng người Brasil', '{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--23
('14c51782-884c-4577-80f2-c28b7ae36afb', N'José Mauro de Vasconcelos', '1920-02-26', N'José Mauro de Vasconcelos là một nhà văn người Brazil','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--24
('7c4e7db4-3649-426b-aef5-cbdd95e81dab', N'Hae Min', '1973-12-12', N'aemin là một giáo viên và nhà văn người Hàn Quốc theo truyền thống Phật giáo Seon','{}',
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0)
------------------------------------AppBlocks
insert into Library.AppBlocks(Id, NameBlock, NumberBookInBlock, Capacity, AvailableSpace, ExtraProperties, ConcurrencyStamp, CreationTime, CreatorId, IsDeleted)
values
--1
('de8c77a5-f598-4e64-96fd-001a4435de36', N'A-01-01-01', 20, 40, 20, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--2
('bd43c004-0580-4f0b-8ba6-002830720bc6', N'B-02-02-03', 35, 50, 15, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--3
('e80c05e6-368b-4406-a5f0-02aa74791204', N'C-04-01-03', 20, 50, 30, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--4
('723cff6a-3d00-40e2-a0fb-091fc102af29', N'D-02-04-01', 33, 50, 17, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--5
('334dd58f-f406-4eb9-853f-0dc6e00812cd', N'E-01-02-03', 26, 40, 14, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--6
('7378a846-fa2b-4be1-9d2b-21fc59647b9e', N'F-01-05-03', 35, 70, 35, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--7
('0cd92e1d-6752-02fd-1654-3a0153b47cd2', N'G-02-06-01', 34, 55, 21, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--8
('dd33def9-03fd-56e1-ddf7-3a018c6faf60', N'A-01-02-03', 40, 40, 0, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--9
('7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', N'B-03-05-03', 50, 50, 0, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--10
('a7a89b1f-7a85-48eb-ac3a-728b007b084c', N'C-04-05-03', 0, 50, 50, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--11
('f101b2eb-9734-4afd-8380-784b226bbe96', N'C-02-03-03', 0, 40, 40, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--12
('2a010958-6336-4858-8462-813c9b3a4884', N'C-01-05-05', 0, 30, 30, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0)

------------------------------------AppBooks
insert into Library.AppBooks(Id, NameBook, DatePublish, Price, IdCategory, IdAuthor, IdBlock, NumberBook, ExtraProperties, ConcurrencyStamp, CreationTime, CreatorId, IsDeleted)
values
--1
('9ebc9ee5-27d8-4da3-85d5-13bce908e7b9', N'Giáo Trình Đại Số Đại Cương', '2008-04-06', 120000, 
'406a450b-5121-4156-858e-76c195a85392', -- Bảng category lấy Id giáo trình
'ec59a588-4b5b-4c1f-a3b1-c738fc4a6ea1',  -- Bảng Author lấy Id Đỗ Nguyên Sơn
'de8c77a5-f598-4e64-96fd-001a4435de36', -- Bảng Block lấy Id của A-01-01-01
20, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--2
('7dfbf902-5d23-46f0-8273-196256862793', N'Đọc vị bất kỳ ai', '2007-02-04', 200000, 
'6b09075e-5a34-4e17-90c5-fc3fb813bfe6', -- Bảng category lấy Id Tâm lý
'ea0642c5-1070-400e-be8b-6f1675a023bf',  -- Bảng Author lấy Id David J. Lieberman
'bd43c004-0580-4f0b-8ba6-002830720bc6', -- Bảng Block lấy Id của B-02-02-03
20, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--3
('95d7f406-06a8-4136-800b-2199307bca1a', N'Đời ngắn đừng ngủ dài', '2007-04-06', 80000, 
'338e7721-cc71-4515-b82c-1c7f903392f7', -- Bảng category lấy Id tự lực
'da39a999-e9b9-4d9d-8f19-950627327cee',  -- Bảng Author lấy Id Robin Sharma
'bd43c004-0580-4f0b-8ba6-002830720bc6', -- Bảng Block lấy Id của B-02-02-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--4
('0e03c93c-af65-4ea0-9ebd-23dcefbf3711', N'Đắc nhân tâm', '2004-02-05', 60000, 
'338e7721-cc71-4515-b82c-1c7f903392f7', -- Bảng category lấy Id tự lực
'247d26c1-39f6-45ce-a694-9c73c06d1a9e',  -- Bảng Author lấy Id Dale Carnegie
'bd43c004-0580-4f0b-8ba6-002830720bc6', -- Bảng Block lấy Id của B-02-02-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--5
('ff828ae2-5d29-4973-ae43-2c4b2e40c987', N'7 thói quen hiệu quả', '2006-04-06', 150000, 
'338e7721-cc71-4515-b82c-1c7f903392f7', -- Bảng category lấy Id tự lực
'd553ac37-400c-4ee6-81ba-9e11024eaf0b',  -- Bảng Author lấy Id Stephen Covey
'e80c05e6-368b-4406-a5f0-02aa74791204', -- Bảng Block lấy Id của C-04-01-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--6
('675e2e59-6927-4eb7-b4f9-39505cda6965', N'Tuổi thơ dữ dội', '2009-02-12', 210000, 
'c4cb8023-ebd6-4fd3-9ca3-1c95d996e0d5', -- Bảng category lấy Id văn học
'a19f5ed1-f058-42b4-89d4-a702778b9027',  -- Bảng Author lấy Id Phùng Quáng
'e80c05e6-368b-4406-a5f0-02aa74791204', -- Bảng Block lấy Id của C-04-01-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--7
('b4b94756-aad5-473d-a5c4-49cfbbfa0cca', N'Giết con chim nhại', '2010-10-06', 160000, 
'c4cb8023-ebd6-4fd3-9ca3-1c95d996e0d5', -- Bảng category lấy Id văn học
'daeff859-80a1-4b36-8c23-aacd6490f436',  -- Bảng Author lấy Id Harper Lee
'723cff6a-3d00-40e2-a0fb-091fc102af29', -- Bảng Block lấy Id của D-02-04-01
20, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--8
('89bd753e-b45a-4ea9-872f-4a4eb7b8af5b', N'Chiến tranh và Hòa bình', '2011-07-04', 90000, 
'c4cb8023-ebd6-4fd3-9ca3-1c95d996e0d5', -- Bảng category lấy Id văn học
'ad09b7c8-6f35-4210-9a1e-af9a04ae9704',  -- Bảng Author lấy Id Lev Nikolayevich Tolstoy
'723cff6a-3d00-40e2-a0fb-091fc102af29', -- Bảng Block lấy Id của D-02-04-01
13, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--9
('ec9d9f52-9bee-47b8-8a58-715b11106dbb', N'Lược Sử Vạn Vật', '2001-06-04', 50000, 
'0a1c4094-da55-4775-b803-5b77f08b39a1', -- Bảng category lấy Id khoa học
'40b9a0f4-64c5-4711-ae23-cc488165098c',  -- Bảng Author lấy Id Bill Bryson
'7378a846-fa2b-4be1-9d2b-21fc59647b9e', -- Bảng Block lấy Id của F-01-05-03
15, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--10
('26a12900-c318-478a-b09a-ed16de448346', N'Cuộc Đời Và Vũ Trụ', '2005-04-08', 85000, 
'0a1c4094-da55-4775-b803-5b77f08b39a1', -- Bảng category lấy Id khoa học
'e4ce70e9-ad2d-4341-936b-e68e58edf769',  -- Bảng Author lấy Id Einstein
'0cd92e1d-6752-02fd-1654-3a0153b47cd2', -- Bảng Block lấy Id của G-02-06-01
17, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--11
('8bf4fd92-59d7-48ce-b5d6-893fb091f58c', N'GEN: Lịch Sử Và Tương Lai Của Nhân Loại', '2008-03-04', 67000, 
'0a1c4094-da55-4775-b803-5b77f08b39a1', -- Bảng category lấy Id khoa học
'd00fbe2d-ec1d-4dda-a9be-f29a4ae1751a',  -- Bảng Author lấy Id Pranab Mukherjee
'0cd92e1d-6752-02fd-1654-3a0153b47cd2', -- Bảng Block lấy Id của G-02-06-01
17, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--12
('00dfc62d-1f65-4bf4-8b4e-8db5cdb636c9', N'Dẫn luận về xã hội học', '2009-02-09', 78000, 
'52cbfd6f-b33c-43a3-8380-83d3f5a2e560', -- Bảng category lấy Id xã hội học
'304e2678-5ed8-41ec-8e4c-05b9a9c1d626',  -- Bảng Author lấy Id Emile Durkheim
'dd33def9-03fd-56e1-ddf7-3a018c6faf60', -- Bảng Block lấy Id của A-01-02-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--13
('5f462e70-40a1-4194-956d-9b5286ad7f23', N'Lời mời đến với xã hội học', '2010-02-04', 202000, 
'52cbfd6f-b33c-43a3-8380-83d3f5a2e560', -- Bảng category lấy Id xã hội học
'd0df0f13-66be-441b-b664-088b5c0f60f9',  -- Bảng Author lấy Id Peter L. Berger
'dd33def9-03fd-56e1-ddf7-3a018c6faf60', -- Bảng Block lấy Id của A-01-02-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--14
('850cca32-8bfe-4413-990a-a0a1758e519c', N'Đời sống con người và xã hội hôm nay', '2011-09-08', 89000, 
'52cbfd6f-b33c-43a3-8380-83d3f5a2e560', -- Bảng category lấy Id xã hội học
'063cf781-ebbf-456c-84e9-0c4056120e62',  -- Bảng Author lấy Id Ajahn Chah
'dd33def9-03fd-56e1-ddf7-3a018c6faf60', -- Bảng Block lấy Id của A-01-02-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--15
('caf5e8d6-2a49-4b8e-af7a-a522a7598c76', N'Sinh lý học Y khoa', '2007-07-07', 56000, 
'2157028b-7c97-4700-bb83-70d1f1fd4e33', -- Bảng category lấy Id y học
'361b0ad5-9257-412c-88bb-21f5c7cd4c45',  -- Bảng Author lấy Id Phạm Đình Lựu
'dd33def9-03fd-56e1-ddf7-3a018c6faf60', -- Bảng Block lấy Id của A-01-02-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--16
('e00fdb8e-1127-41d1-8653-af47edb23111', N'Atlas Giải Phẫu người', '2003-12-12', 110000, 
'2157028b-7c97-4700-bb83-70d1f1fd4e33', -- Bảng category lấy Id y học
'023745ac-c028-4864-978d-358d6929a0be',  -- Bảng Author lấy Frank H. Netter
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--17
('71071bc8-23b7-46b8-b98e-bd3dd4fe2988', N'Hướng dẫn chuẩn đoán và điều trị Bệnh Nội khoa', '2000-02-02', 145000, 
'2157028b-7c97-4700-bb83-70d1f1fd4e33', -- Bảng category lấy Id y học
'706e498b-d51f-486a-83ec-395a1866460f',  -- Bảng Author lấy Id Nguyễn Quốc Anh
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--18
('e8a67655-9e97-49ae-8b0a-cf924cfecff9', N'Kinh Tế Học Vĩ Mô (2021)', '2008-04-06', 123000, 
'406a450b-5121-4156-858e-76c195a85392', -- Bảng category lấy Id giáo trình
'b256ea41-ebe6-411c-9a5d-3df624f31481',  -- Bảng Author lấy Id N. Gregory Mankiw
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--19
('2ca31c13-b48d-40eb-9cde-dba40b7c4895', N'Giáo Trình Lý Thuyết Tài Chính - Tiền Tệ', '2009-02-12', 167000, 
'406a450b-5121-4156-858e-76c195a85392', -- Bảng category lấy Id giáo trình
'd8452122-a067-4fce-a025-43d692f615f6',  -- Bảng Author lấy Id Phan Thị Cúc
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--20
('9171268f-4299-47b9-ab6c-efe04bfe150b', N'Phi Lý Trí', '2009-09-06', 134000, 
'6b09075e-5a34-4e17-90c5-fc3fb813bfe6', -- Bảng category lấy Id Tâm lý
'7e23acc8-53e2-415f-93c8-5e1ec853135b',  -- Bảng Author lấy Id Dan Ariely
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--21
('b779042b-8a75-4432-a92b-4e3bac3d58e2', N'Tình Cờ Gặp Hạnh Phúc', '2002-02-02', 29000, 
'6b09075e-5a34-4e17-90c5-fc3fb813bfe6', -- Bảng category lấy Id Tâm lý
'a75997ff-f8d1-4c6e-bf1d-67c8295913b7',  -- Bảng Author lấy Id Daniel Gilbert
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
10, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--22
('314f017f-3416-4b97-9507-07098d8801ce', N'Nhà Giả Kim', '2004-04-06', 230000, 
'09faf44c-84f4-42ce-bd7f-1626326c1bde', -- Bảng category lấy Id tiểu thuyết
'e19efb1c-61f0-44f3-8889-ac1d8d3b0f00',  -- Bảng Author lấy Id Paulo Coelho
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--23
('ca7170c6-e21d-4a38-ad30-fe124752e6ef', N'Cây Cam Ngọt Của Tôi', '2006-02-04', 83000, 
'09faf44c-84f4-42ce-bd7f-1626326c1bde', -- Bảng category lấy Id tiểu thuyết
'14c51782-884c-4577-80f2-c28b7ae36afb',  -- Bảng Author lấy Id José Mauro de Vasconcelos
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--24
('d1dbc490-fdb4-48f4-a6fc-fead7b421f3e', N'Bước Chậm Lại Giữa Thế Gian Vội Vã', '2005-04-06', 58000, 
'09faf44c-84f4-42ce-bd7f-1626326c1bde', -- Bảng category lấy Id tiểu thuyết
'7c4e7db4-3649-426b-aef5-cbdd95e81dab',  -- Bảng Author lấy Id Hae Min
'7d442fe5-cba0-4d09-b1f4-4c4fa73b14b4', -- Bảng Block lấy Id của B-03-05-03
5, '{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0)


------------------------------------AppReaders
insert into Library.AppReaders(Id, NameReader, Age, Address, Phone, Email, IdCard, ExtraProperties, ConcurrencyStamp, CreationTime, CreatorId, IsDeleted)
values
--1
('ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7', N'Cù Đỗ Thanh Nhân', 20, N'Đà Nẵng', '0707472367', 'nhancu13579@gmail.com', 'CMND01', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--2
('c57f9c09-7703-4a0e-a6a1-04bbd122e063', N'Doãn Lê Thế Bảo', 21, N'Hồ Chí Minh', '0712937162', 'doanbao0123@gmail.com', 'CMND02', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--3
('d02b0c8c-b1c2-4073-b671-44a231abcc66', N'Phan Trung Hiếu', 19, N'Huế', '0932215660', 'Hieucute@gmail.com', 'CMND03', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--4
('95a0be9a-c191-4bb9-b63d-f1790039b3e9', N'Nguyễn Tiến Sơn', 21, N'Đà Nẵng', '0982343332', 'TienSonDeep@gmail.com', 'CMND04', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--5
('445a12aa-674e-4f84-a801-4458ea9add0b', N'Huỳnh Trần Bảo Minh', 23, N'Hà Nội', '0123683710', 'BMinhToCon@gmail.com', 'CMND05', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--6
('3e154502-55a8-4a7d-8b50-b7c2fa313cca', N'Vũ Thị Thảo Nhi', 17, N'Hồ Chí Minh', '0836712944', 'NhiHieuTruong@gmail.com', 'CMND06', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--7
('8a71dbb1-6ed2-40b1-a3c7-db1d5efde54f', N'Trần Thị Ngọc Minh', 22, N'Vũng Tàu', '0882374123', 'Minhbeo@gmail.com', 'CMND07', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--8
('1cb227f5-7194-4ddc-b654-e38341a42ea4', N'Võ Ái Nhi', 20, N'Huế', '0998312883', 'NhiVo123@gmail.com', 'CMND08', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--9
('60b91b9c-8493-48d3-8d54-c305e95432fb', N'Nguyễn Văn Danh', 19, N'Quảng Nam', '0119034187', 'DanhVanNguyen@gmail.com', 'CMND09', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--10
('07e0c09a-7db8-4436-9249-4780ed37d169', N'Nguyễn Thị Thùy Dung', 18, N'Huế', '0989334517', 'Dungnhobe@gmail.com', 'CMND010', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--11
('52c63a0d-6ae7-4704-afee-9fb62f39190a', N'Vũ Tiến Lực', 18, N'Lào Cai', '0989755438', 'VuTienLuc@gmail.com', 'CMND011', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--12
('17fc3dd4-047b-4c7d-9ea7-daecacf76952', N'Uyển Nhi', 18, N'Quảng Trị', '0123441172', 'NhiDuHoc@gmail.com', 'CMND012', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--13
(N'addf32c7-f5c6-4785-80b4-d96b634926ad', N'Nguyễn Khánh Như', 18, N'Mỹ', '0341255629', 'Nhu@gmail.com', 'CMND013', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--14
('897128d4-6f29-44d8-a378-fe38183b9573', N'Lê Tự Thành Vinh', 18, N'Nghệ An', '0987831762', 'VinhChuaHe@gmail.com', 'CMND014', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--15
('297311c8-6def-498a-87f5-dd5bf0ee75f2', N'Như Quỳnh', 18, N'Đà Nẵng', '0677582981', 'VinhChuaHe@gmail.com', 'CMND015', '{}', 
LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0)
------------------------------------AppBorrows
insert into Library.AppBorrows(Id, DateBorrow, DateReturn, IsReturnBook, IdBook, IdReader, ExtraProperties, ConcurrencyStamp, CreationTime, CreatorId, IsDeleted)
values
--1
('23bc29af-ad99-45b0-b87f-02b8b81a5c17', '2020-01-01', '2020-01-15', 1, 
'9ebc9ee5-27d8-4da3-85d5-13bce908e7b9',   -- Bảng Book lấy Id của 'Giáo trình đại số đại cương'
'ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7',   -- Bảng Reader lấy Id của 'Cù Đỗ Thanh Nhân'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--2
('92cf1da8-a8e8-4f26-96cd-08a1bb65a559', '2020-01-12', '2020-01-26', 1, 
'7dfbf902-5d23-46f0-8273-196256862793',   -- Bảng Book lấy Id của 'Đọc vị bất kỳ ai'
'c57f9c09-7703-4a0e-a6a1-04bbd122e063b',   -- Bảng Reader lấy Id của 'Doãn Lê Thế Bảo'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--3
('53e2b65e-2b2b-4dc0-8116-08da8598bf08', '2020-02-12', '2020-02-16', 1, 
'95d7f406-06a8-4136-800b-2199307bca1a',   -- Bảng Book lấy Id của 'Đời ngắn đừng ngủ dài'
'ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7',   -- Bảng Reader lấy Id của 'Cù Đỗ Thanh Nhân'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--4
('3d48e090-d018-4bb2-aeaa-267df73894dd', '2020-02-12', '2020-02-26', 1, 
'0e03c93c-af65-4ea0-9ebd-23dcefbf3711',   -- Bảng Book lấy Id của 'Đắc nhân tâm'
'ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7',   -- Bảng Reader lấy Id của 'Cù Đỗ Thanh Nhân'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--5
('35fa13d6-92b2-4b40-9375-286a074bc23f', '2020-02-14', '2020-02-28', 1, 
'0e03c93c-af65-4ea0-9ebd-23dcefbf3711',   -- Bảng Book lấy Id của 'Đắc nhân tâm'
'c57f9c09-7703-4a0e-a6a1-04bbd122e063b',   -- Bảng Reader lấy Id của 'Doãn Lê Thế Bảo'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--6
('165661f2-6fa9-499d-aad5-309fa56fda26', '2020-03-14', '2020-03-28', 1, 
'675e2e59-6927-4eb7-b4f9-39505cda6965',   -- Bảng Book lấy Id của 'Tuổi thơ dữ dội'
'd02b0c8c-b1c2-4073-b671-44a231abcc66',   -- Bảng Reader lấy Id của 'Phan Trung Hiếu'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--7
('25d620ce-645c-428f-bc3e-3491564cf655', '2020-03-14', '2020-03-28', 1, 
'0e03c93c-af65-4ea0-9ebd-23dcefbf3711',   -- Bảng Book lấy Id của 'Đắc nhân tâm'
'd02b0c8c-b1c2-4073-b671-44a231abcc66',   -- Bảng Reader lấy Id của 'Phan Trung Hiếu'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--8
('2d45e2ff-faba-42bb-9b69-37e6fb6b289f', '2020-03-15', '2020-03-29', 1, 
'e00fdb8e-1127-41d1-8653-af47edb23111',   -- Bảng Book lấy Id của 'Atlas Giải Phẫu người'
'95a0be9a-c191-4bb9-b63d-f1790039b3e9',   -- Bảng Reader lấy Id của 'Nguyễn Tiến Sơn'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--9
('3a9abc02-6d7a-4756-b53d-38878e41a2fb', '2020-04-15', '2020-04-29', 1, 
'71071bc8-23b7-46b8-b98e-bd3dd4fe2988',   -- Bảng Book lấy Id của 'Hướng dẫn chuẩn đoán và điều trị Bệnh Nội khoa'
'95a0be9a-c191-4bb9-b63d-f1790039b3e9',   -- Bảng Reader lấy Id của 'Nguyễn Tiến Sơn'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--10
('5d8a2c6c-6117-4f23-92cc-3ddc77828fc7', '2020-04-15', '2020-04-29', 1, 
'ca7170c6-e21d-4a38-ad30-fe124752e6ef',   -- Bảng Book lấy Id của 'Cây cam ngọt của tôi'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--11
('d195a925-4dc5-41fc-8730-480b5941afaa', '2020-04-15', '2020-04-29', 1, 
'9ebc9ee5-27d8-4da3-85d5-13bce908e7b9',   -- Bảng Book lấy Id của 'Giáo trình đại số đại cương'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--12
('070b945c-45ff-49e9-b5a4-4c05026c6e7b', '2020-04-15', '2020-04-29', 1, 
'314f017f-3416-4b97-9507-07098d8801ce',   -- Bảng Book lấy Id của 'Nhà giả kim'
'3e154502-55a8-4a7d-8b50-b7c2fa313cca',   -- Bảng Reader lấy Id của 'Vũ Thị Thảo Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--13
('c1d63a9b-69fa-496a-aafe-59c6b817b2af', '2020-04-16', '2020-04-30', 1, 
'ca7170c6-e21d-4a38-ad30-fe124752e6ef',   -- Bảng Book lấy Id của 'Cây cam ngọt của tôi'
'3e154502-55a8-4a7d-8b50-b7c2fa313cca',   -- Bảng Reader lấy Id của 'Vũ Thị Thảo Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--14
('f296ed39-8b88-4060-9df4-5bcc240b451f', '2020-04-16', '2020-04-30', 1, 
'26a12900-c318-478a-b09a-ed16de448346',   -- Bảng Book lấy Id của 'Cuộc đời và vũ trụ'
'3e154502-55a8-4a7d-8b50-b7c2fa313cca',   -- Bảng Reader lấy Id của 'Vũ Thị Thảo Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--15
('0a6142a0-671e-4748-ae83-5bd4544a641a', '2020-05-16', '2020-05-30', 1, 
'26a12900-c318-478a-b09a-ed16de448346',   -- Bảng Book lấy Id của 'Cuộc đời và vũ trụ'
'8a71dbb1-6ed2-40b1-a3c7-db1d5efde54f',   -- Bảng Reader lấy Id của 'Trần Thị Ngọc Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--16
('9dbc3a06-0518-458c-b10e-64da9573871c', '2020-05-16', '2020-05-30', 1, 
'314f017f-3416-4b97-9507-07098d8801ce',   -- Bảng Book lấy Id của 'Nhà Giả Kim'
'8a71dbb1-6ed2-40b1-a3c7-db1d5efde54f',   -- Bảng Reader lấy Id của 'Trần Thị Ngọc Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--17
('5877d11e-1381-42a4-9462-72e9eb640a7c', '2020-05-18', '2020-06-02', 1, 
'd1dbc490-fdb4-48f4-a6fc-fead7b421f3e',   -- Bảng Book lấy Id của 'Bước chậm lại giữa thế giới vội vã'
'1cb227f5-7194-4ddc-b654-e38341a42ea4',   -- Bảng Reader lấy Id của 'Võ Ái Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--18
('7d6a8e4f-f831-4352-a2c7-882412dee857', '2020-01-18', '2020-02-02', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Tình cờ gặp hạnh phúc'
'1cb227f5-7194-4ddc-b654-e38341a42ea4',   -- Bảng Reader lấy Id của 'Võ Ái Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--19
('04c9c627-886d-400f-9655-8c6956aa1ef9', '2020-05-18', '2020-06-02', 1, 
'e8a67655-9e97-49ae-8b0a-cf924cfecff9',   -- Bảng Book lấy Id của 'Kinh tế học vĩ mô(2021)'
'1cb227f5-7194-4ddc-b654-e38341a42ea4',   -- Bảng Reader lấy Id của 'Võ Ái Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--20
('66942637-c519-475f-926f-8ecbb94cca53', '2020-06-19', '2020-07-03', 1, 
'850cca32-8bfe-4413-990a-a0a1758e519c',   -- Bảng Book lấy Id của 'Đời sống con người và xã hội hôm nay'
'1cb227f5-7194-4ddc-b654-e38341a42ea4',   -- Bảng Reader lấy Id của 'Võ Ái Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--21
('c9c4456e-cf9a-4763-8cfd-8f32f16636fa', '2020-06-19', '2020-07-03', 1, 
'e8a67655-9e97-49ae-8b0a-cf924cfecff9',   -- Bảng Book lấy Id của 'Kinh tế học vĩ mô(2021)'
'60b91b9c-8493-48d3-8d54-c305e95432fb',   -- Bảng Reader lấy Id của 'Nguyễn Văn Danh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--22
('72fa8901-f8fb-42ba-a744-9681a203448f', '2020-06-19', '2020-07-03', 1, 
'850cca32-8bfe-4413-990a-a0a1758e519c',   -- Bảng Book lấy Id của 'Đời sống con người và xã hội hôm nay'
'60b91b9c-8493-48d3-8d54-c305e95432fb',   -- Bảng Reader lấy Id của 'Nguyễn Văn Danh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--23
('8c14e14f-37cb-4cdf-b77f-9738933c8222', '2020-07-05', '2020-07-19', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Tình cờ gặp hạnh phúc'
'60b91b9c-8493-48d3-8d54-c305e95432fb',   -- Bảng Reader lấy Id của 'Nguyễn Văn Danh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--24
('26d1766b-92e7-4862-a59d-98bc5c8b8f6d', '2020-07-09', '2020-07-23', 1, 
'9171268f-4299-47b9-ab6c-efe04bfe150b',   -- Bảng Book lấy Id của 'Phi Lý Trí'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--25
('d6c0caf7-199f-41e4-b97f-9920374093b5', '2020-07-09', '2020-07-23', 1, 
'2ca31c13-b48d-40eb-9cde-dba40b7c4895',   -- Bảng Book lấy Id của 'Giáo Trình Lý Thuyết Tài Chính - Tiền Tệ'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--26
('cfc6d08a-7047-43e9-9947-9c32d6d959c6', '2020-07-11', '2020-07-25', 1, 
'caf5e8d6-2a49-4b8e-af7a-a522a7598c76',   -- Bảng Book lấy Id của 'Sinh lý học Y khoa'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--27
('b3ba89fa-8fa7-4270-bc54-a1c646fa141e', '2020-07-15', '2020-07-29', 1, 
'caf5e8d6-2a49-4b8e-af7a-a522a7598c76',   -- Bảng Book lấy Id của 'Sinh lý học Y khoa'
'52c63a0d-6ae7-4704-afee-9fb62f39190a',   -- Bảng Reader lấy Id của 'Vũ Tiến Lực'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--28
('9cbe6852-7e17-4d3e-8736-b0a4f60a288e', '2020-08-01', '2020-08-15', 1, 
'9171268f-4299-47b9-ab6c-efe04bfe150b',   -- Bảng Book lấy Id của 'Phi Lý Trí'
'52c63a0d-6ae7-4704-afee-9fb62f39190a',   -- Bảng Reader lấy Id của 'Vũ Tiến Lực'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--29
('b277e117-9569-448a-9b75-b0b4c00a3e2b', '2020-08-03', '2020-08-17', 1, 
'ec9d9f52-9bee-47b8-8a58-715b11106dbb',   -- Bảng Book lấy Id của 'Lược sử vạn vật'
'52c63a0d-6ae7-4704-afee-9fb62f39190a',   -- Bảng Reader lấy Id của 'Vũ Tiến Lực'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--30
('834e5e6c-19cc-448b-bd63-b67be1082ee1', '2020-08-05', '2020-08-17', 1, 
'ec9d9f52-9bee-47b8-8a58-715b11106dbb',   -- Bảng Book lấy Id của 'Lược sử vạn vật'
'17fc3dd4-047b-4c7d-9ea7-daecacf76952',   -- Bảng Reader lấy Id của 'Uyển Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--31
('66d474bf-0e2c-45d5-85b3-b90e6dd6e335', '2020-08-13', '2020-08-22', 1, 
'0e03c93c-af65-4ea0-9ebd-23dcefbf3711',   -- Bảng Book lấy Id của 'Đắc nhân tâm'
'17fc3dd4-047b-4c7d-9ea7-daecacf76952',   -- Bảng Reader lấy Id của 'Uyển Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--32
('3d22811a-d40e-4f88-848b-bd354307c276', '2020-08-19', '2020-09-03', 1, 
'9171268f-4299-47b9-ab6c-efe04bfe150b',   -- Bảng Book lấy Id của 'Phi Lý Trí'
'17fc3dd4-047b-4c7d-9ea7-daecacf76952',   -- Bảng Reader lấy Id của 'Uyển Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--33
('2b7ec001-8437-4ed9-979c-cf8e2a950e39', '2020-09-01', '2020-09-15', 1, 
'ec9d9f52-9bee-47b8-8a58-715b11106dbb',   -- Bảng Book lấy Id của 'Lược sử vạn vật'
'addf32c7-f5c6-4785-80b4-d96b634926ad',   -- Bảng Reader lấy Id của 'Nguyễn Khánh Như'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--34
('2be07057-d27b-4205-91e2-d83dccf05c35', '2020-09-07', '2020-09-21', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Tình cờ gặp hạnh phúc'
'addf32c7-f5c6-4785-80b4-d96b634926ad',   -- Bảng Reader lấy Id của 'Nguyễn Khánh Như'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--35
('b3e986ba-6c5c-4e7f-8a68-d8721a13d106', '2020-10-01', '2020-10-15', 1, 
'850cca32-8bfe-4413-990a-a0a1758e519c',   -- Bảng Book lấy Id của 'Đời sống con người và xã hội hôm nay'
'addf32c7-f5c6-4785-80b4-d96b634926ad',   -- Bảng Reader lấy Id của 'Nguyễn Khánh Như'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--36
('e170ead5-34e1-432d-a362-dbafc1ca03b6', '2020-12-01', '2020-12-15', 1, 
'd1dbc490-fdb4-48f4-a6fc-fead7b421f3e',   -- Bảng Book lấy Id của 'Bước chậm lại giữa thế giới vội vã'
'addf32c7-f5c6-4785-80b4-d96b634926ad',   -- Bảng Reader lấy Id của 'Nguyễn Khánh Như'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--37
('122b9dd1-1a58-43e2-b624-df0d0bb3b736', '2022-01-01', '2022-01-15', 0, 
'675e2e59-6927-4eb7-b4f9-39505cda6965',   -- Bảng Book lấy Id của 'Tuổi thơ dữ dội'
'addf32c7-f5c6-4785-80b4-d96b634926ad',   -- Bảng Reader lấy Id của 'Nguyễn Khánh Như'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--38
('3dbe4a2f-e729-42e9-985b-e28ff17ca45a', '2022-01-05', '2022-01-19', 0, 
'00dfc62d-1f65-4bf4-8b4e-8db5cdb636c9',   -- Bảng Book lấy Id của 'Dẫn luận về xã hội học'
'897128d4-6f29-44d8-a378-fe38183b9573',   -- Bảng Reader lấy Id của 'Lê Tự Thành Vinh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--39
('fcef378f-58a4-4876-adb5-e6f6cf9e5a7c', '2022-01-07', '2022-01-21', 0, 
'ff828ae2-5d29-4973-ae43-2c4b2e40c987',   -- Bảng Book lấy Id của '7 thói quen hiệu quả'
'897128d4-6f29-44d8-a378-fe38183b9573',   -- Bảng Reader lấy Id của 'Lê Tự Thành Vinh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--40
('8d1781ca-56fc-4a6d-a75b-f327d24b6bd5', '2022-01-24', '2022-02-08', 0, 
'00dfc62d-1f65-4bf4-8b4e-8db5cdb636c9',   -- Bảng Book lấy Id của 'Dẫn luận về xã hội học'
'297311c8-6def-498a-87f5-dd5bf0ee75f2',   -- Bảng Reader lấy Id của 'Như Quỳnh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--41
('0f1a4125-c7b2-48fa-a021-ff85d10abf79', '2022-01-25', '2022-02-09', 0, 
'ff828ae2-5d29-4973-ae43-2c4b2e40c987',   -- Bảng Book lấy Id của '7 thói quen hiệu quả'
'297311c8-6def-498a-87f5-dd5bf0ee75f2',   -- Bảng Reader lấy Id của 'Như Quỳnh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--42
('7a04cf97-42f0-4235-b011-01821ba2bad5', '2020-01-03', '2020-01-18', 1, 
'675e2e59-6927-4eb7-b4f9-39505cda6965',   -- Bảng Book lấy Id của 'Tuổi thơ dữ dội'
'ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7',   -- Bảng Reader lấy Id của 'Cù Đỗ Thanh Nhân'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--43
('b75c3521-f97b-46a2-b9f6-038ed1e6952a', '2020-01-04', '2020-01-19', 1, 
'ca7170c6-e21d-4a38-ad30-fe124752e6ef',   -- Bảng Book lấy Id của 'Cây cam ngọt của tôi'
'ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7',   -- Bảng Reader lấy Id của 'Cù Đỗ Thanh Nhân'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--44
('6721fe8f-0209-4646-9d6e-0c8d402e845e', '2020-01-05', '2020-01-20', 1, 
'71071bc8-23b7-46b8-b98e-bd3dd4fe2988',   -- Bảng Book lấy Id của 'Hướng dẫn chuẩn đoán và điều trị Bệnh Nội khoa'
'ea4b4e0f-3b18-4c2d-b7d9-dcbc90ffaae7',   -- Bảng Reader lấy Id của 'Cù Đỗ Thanh Nhân'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--45
('7ee85b85-fb80-4747-90ed-1744394c56da', '2020-01-15', '2020-01-29', 1, 
'95d7f406-06a8-4136-800b-2199307bca1a',   -- Bảng Book lấy Id của 'Đời ngắn đừng ngủ dài'
'c57f9c09-7703-4a0e-a6a1-04bbd122e063b',   -- Bảng Reader lấy Id của 'Doãn Lê Thế Bảo'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--46
('689bbdef-a978-4332-b526-18265bb81b11', '2020-01-12', '2020-01-26', 1, 
'e00fdb8e-1127-41d1-8653-af47edb23111',   -- Bảng Book lấy Id của 'Atlas Giải Phẫu người'
'c57f9c09-7703-4a0e-a6a1-04bbd122e063b',   -- Bảng Reader lấy Id của 'Doãn Lê Thế Bảo'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--47
('5bb5d1e2-34c2-4a70-9c4d-1aee1ee8598a', '2020-01-13', '2020-01-27', 1, 
'314f017f-3416-4b97-9507-07098d8801ce',   -- Bảng Book lấy Id của 'Nhà giả kim'
'c57f9c09-7703-4a0e-a6a1-04bbd122e063b',   -- Bảng Reader lấy Id của 'Doãn Lê Thế Bảo'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--48
('a1511f00-837a-4392-9543-205ab97c9ba1', '2020-01-12', '2020-01-26', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Tình cờ gặp hạnh phúc'
'c57f9c09-7703-4a0e-a6a1-04bbd122e063b',   -- Bảng Reader lấy Id của 'Doãn Lê Thế Bảo'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--49
('204abd50-9a71-4c01-b9c5-2bf7b7a96f6d', '2020-03-15', '2020-03-29', 1, 
'd1dbc490-fdb4-48f4-a6fc-fead7b421f3e',   -- Bảng Book lấy Id của 'Bước chậm lại giữa thế giới vội vã'
'd02b0c8c-b1c2-4073-b671-44a231abcc66',   -- Bảng Reader lấy Id của 'Phan Trung Hiếu'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--50
('52732d84-1f1e-4fa8-a7f9-2fc98cae234d', '2020-03-14', '2020-03-28', 1, 
'26a12900-c318-478a-b09a-ed16de448346',   -- Bảng Book lấy Id của 'Cuộc đời và vũ trụ'
'd02b0c8c-b1c2-4073-b671-44a231abcc66',   -- Bảng Reader lấy Id của 'Phan Trung Hiếu'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--51
('70dd5ebb-de69-46d2-84e8-2ff246efa2c1', '2020-03-18', '2020-04-02', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Tình cờ gặp hạnh phúc'
'd02b0c8c-b1c2-4073-b671-44a231abcc66',   -- Bảng Reader lấy Id của 'Phan Trung Hiếu'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--52
('f5faeccf-20f0-4a9a-8eb3-3a9257c696dd', '2020-03-15', '2020-03-29', 1, 
'314f017f-3416-4b97-9507-07098d8801ce',   -- Bảng Book lấy Id của 'Nhà giả kim'
'95a0be9a-c191-4bb9-b63d-f1790039b3e9',   -- Bảng Reader lấy Id của 'Nguyễn Tiến Sơn'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--53
('cc1af9a8-96b9-445d-ac05-65ccf503f162', '2020-03-16', '2020-03-30', 1, 
'9ebc9ee5-27d8-4da3-85d5-13bce908e7b9',   -- Bảng Book lấy Id của 'Giáo trình đại số đại cương'
'95a0be9a-c191-4bb9-b63d-f1790039b3e9',   -- Bảng Reader lấy Id của 'Nguyễn Tiến Sơn'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--54
('d492f829-e0cc-45f9-910e-688f22210473', '2021-03-11', '2021-03-25', 1, 
'e8a67655-9e97-49ae-8b0a-cf924cfecff9',   -- Bảng Book lấy Id của 'Kinh tế học vĩ mô(2021)'
'95a0be9a-c191-4bb9-b63d-f1790039b3e9',   -- Bảng Reader lấy Id của 'Nguyễn Tiến Sơn'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--55
('5e1a7368-c593-42fe-b1ed-6ad3e40b588c', '2021-04-12', '2021-04-26', 1, 
'314f017f-3416-4b97-9507-07098d8801ce',   -- Bảng Book lấy Id của 'Nhà giả kim'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--56
('125d05e9-1049-4a36-bb0b-6c4bd290006e', '2021-04-13', '2021-04-27', 1, 
'd1dbc490-fdb4-48f4-a6fc-fead7b421f3e',   -- Bảng Book lấy Id của 'Bước chậm lại giữa thế giới vội vã'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--57
('d20766e1-c7f9-4157-b154-6cbcbc74b465', '2021-04-10', '2021-04-24', 1, 
'caf5e8d6-2a49-4b8e-af7a-a522a7598c76',   -- Bảng Book lấy Id của 'Sinh lý học Y khoa'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--58
('738e4d97-1f1e-445b-b7ef-6e7f85bcfabd', '2021-04-1', '2021-04-15', 1, 
'00dfc62d-1f65-4bf4-8b4e-8db5cdb636c9',   -- Bảng Book lấy Id của 'Dẫn luận về xã hội học'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--59
('936a1e88-ee7c-4ffe-b4ae-6edfa2d9b548', '2021-04-05', '2021-04-19', 1, 
'9171268f-4299-47b9-ab6c-efe04bfe150b',   -- Bảng Book lấy Id của 'Phi Lý Trí'
'445a12aa-674e-4f84-a801-4458ea9add0b',   -- Bảng Reader lấy Id của 'Huỳnh Trần Bảo Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--60
('57cce62a-a6c3-416d-877e-6ff786f75f57', '2021-04-15', '2021-04-29', 1, 
'e8a67655-9e97-49ae-8b0a-cf924cfecff9',   -- Bảng Book lấy Id của 'Kinh tế học vĩ mô(2021)'
'3e154502-55a8-4a7d-8b50-b7c2fa313cca',   -- Bảng Reader lấy Id của 'Vũ Thị Thảo Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--61
('a82e09c1-2805-4662-8f5b-7b5d630d988e', '2022-01-14', '2022-01-28', 0, 
'850cca32-8bfe-4413-990a-a0a1758e519c',   -- Bảng Book lấy Id của 'Đời sống con người và xã hội hôm nay'
'3e154502-55a8-4a7d-8b50-b7c2fa313cca',   -- Bảng Reader lấy Id của 'Vũ Thị Thảo Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--62
('edac33a6-8bd9-4c95-ba16-84a9be50dafb', '2022-01-07', '2022-01-21', 0, 
'9171268f-4299-47b9-ab6c-efe04bfe150b',   -- Bảng Book lấy Id của 'Phi Lý Trí'
'3e154502-55a8-4a7d-8b50-b7c2fa313cca',   -- Bảng Reader lấy Id của 'Vũ Thị Thảo Nhi'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--63
('bb93f0c6-b274-41a9-a5c1-8a9a651a5b0a', '2022-02-01', '2022-02-15', 0, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Tình cờ gặp hạnh phúc'
'8a71dbb1-6ed2-40b1-a3c7-db1d5efde54f',   -- Bảng Reader lấy Id của 'Trần Thị Ngọc Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--64
('abe75fc6-7ba8-4b90-a197-8b65d6f8b3d6', '2022-02-04', '2022-02-18', 0, 
'2ca31c13-b48d-40eb-9cde-dba40b7c4895',   -- Bảng Book lấy Id của 'Giáo Trình Lý Thuyết Tài Chính - Tiền Tệ'
'8a71dbb1-6ed2-40b1-a3c7-db1d5efde54f',   -- Bảng Reader lấy Id của 'Trần Thị Ngọc Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--65
('4c7bf288-24b5-419e-a66d-8cf7dcacac83', '2022-02-07', '2022-02-21', 0, 
'caf5e8d6-2a49-4b8e-af7a-a522a7598c76',   -- Bảng Book lấy Id của 'Sinh lý học Y khoa'
'8a71dbb1-6ed2-40b1-a3c7-db1d5efde54f',   -- Bảng Reader lấy Id của 'Trần Thị Ngọc Minh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--66
('43fb5522-f973-40f6-a558-8eb426e91623', '2020-06-19', '2020-07-03', 1, 
'2ca31c13-b48d-40eb-9cde-dba40b7c4895',   -- Bảng Book lấy Id của 'Giáo Trình Lý Thuyết Tài Chính - Tiền Tệ'
'60b91b9c-8493-48d3-8d54-c305e95432fb',   -- Bảng Reader lấy Id của 'Nguyễn Văn Danh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--67
('33f317cc-b57a-435e-8ea3-9658006c11af', '2020-06-19', '2020-07-03', 1, 
'ec9d9f52-9bee-47b8-8a58-715b11106dbb',   -- Bảng Book lấy Id của 'Lược sử vạn vật'
'60b91b9c-8493-48d3-8d54-c305e95432fb',   -- Bảng Reader lấy Id của 'Nguyễn Văn Danh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--68
('fb5c4642-c6c6-4baa-a3a1-97909629917f', '2020-06-19', '2020-07-03', 1, 
'00dfc62d-1f65-4bf4-8b4e-8db5cdb636c9',   -- Bảng Book lấy Id của 'Dẫn luận về xã hội học'
'60b91b9c-8493-48d3-8d54-c305e95432fb',   -- Bảng Reader lấy Id của 'Nguyễn Văn Danh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--69
('a0627eed-562a-4a88-85f2-9ff14936ed6a', '2020-07-09', '2020-07-23', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của 'Lược sử vạn vật'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--70
('dae5522f-fe0b-4257-92a1-a019d18c49f6', '2020-07-09', '2020-07-23', 1, 
'850cca32-8bfe-4413-990a-a0a1758e519c',   -- Bảng Book lấy Id của 'Đời sống con người và xã hội hôm nay'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--71
('3e9561df-14ef-4adb-bb3e-a283666d4320', '2020-07-09', '2020-07-23', 1, 
'b779042b-8a75-4432-a92b-4e3bac3d58e2',   -- Bảng Book lấy Id của ''Tình cờ gặp hạnh phúc'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--72
('8bca648c-7f6f-4f3e-a785-a382d41d1f42', '2020-07-09', '2020-07-23', 1, 
'e8a67655-9e97-49ae-8b0a-cf924cfecff9',   -- Bảng Book lấy Id của 'Kinh tế học vĩ mô(2021)'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--73
('a42cb9c3-b1a1-47bb-973e-a4c80c3b1db0', '2020-07-09', '2020-07-23', 1, 
'675e2e59-6927-4eb7-b4f9-39505cda6965',   -- Bảng Book lấy Id của 'Tuổi thơ dữ dội'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--74
('fee579cc-dfc4-4933-8d37-ad9e37bc78f3', '2020-07-09', '2020-07-23', 1, 
'ff828ae2-5d29-4973-ae43-2c4b2e40c987',   -- Bảng Book lấy Id của '7 thói quen hiệu quả'
'07e0c09a-7db8-4436-9249-4780ed37d169',   -- Bảng Reader lấy Id của 'Nguyễn thị thùy Dung'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--75
('15c0777a-6e0f-4f9e-8d73-b04da5f39933e', '2020-07-15', '2020-07-29', 1, 
'0e03c93c-af65-4ea0-9ebd-23dcefbf3711',   -- Bảng Book lấy Id của 'Đắc nhân tâm'
'52c63a0d-6ae7-4704-afee-9fb62f39190a',   -- Bảng Reader lấy Id của 'Vũ Tiến Lực'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--76
('45945c2b-51e0-4c85-827d-b496a0bbe46a', '2020-07-15', '2020-07-29', 1, 
'71071bc8-23b7-46b8-b98e-bd3dd4fe2988',   -- Bảng Book lấy Id của 'Hướng dẫn chuẩn đoán và điều trị Bệnh Nội khoa'
'52c63a0d-6ae7-4704-afee-9fb62f39190a',   -- Bảng Reader lấy Id của 'Vũ Tiến Lực'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--77
('81a9a728-49d9-44e1-892e-b97f32495c8a', '2020-07-15', '2020-07-29', 1, 
'ff828ae2-5d29-4973-ae43-2c4b2e40c987',   -- Bảng Book lấy Id của '7 thói quen hiệu quả'
'52c63a0d-6ae7-4704-afee-9fb62f39190a',   -- Bảng Reader lấy Id của 'Vũ Tiến Lực'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--79
('3c2a391d-22ed-4fa1-8bfc-bc2253b221dd', '2022-02-08', '2022-02-22', 0, 
'ff828ae2-5d29-4973-ae43-2c4b2e40c987',   -- Bảng Book lấy Id của '7 thói quen hiệu quả'
'297311c8-6def-498a-87f5-dd5bf0ee75f2',   -- Bảng Reader lấy Id của 'Như Quỳnh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0),
--80
('ca450a7f-b54c-470f-bb78-bd9b49e5baaa', '2022-01-29', '2022-02-13', 0, 
'95d7f406-06a8-4136-800b-2199307bca1a',   -- Bảng Book lấy Id của 'Đời ngắn đừng ngủ dài'
'297311c8-6def-498a-87f5-dd5bf0ee75f2',   -- Bảng Reader lấy Id của 'Như Quỳnh'
'{}', LOWER( LEFT (REPLACE(CAST (NEWID () AS NVARCHAR(MAX)), '-', '') , 32)), DATEADD(Day, 2, GETDATE()), NEWID(), 0)
