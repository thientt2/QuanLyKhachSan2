   M S B A M L   `   `   `  ����E  AQLKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLKhachSan
QLKhachSan  5   	   C&clr-namespace:QLKhachSan.UserControlKSQLKhachSan.UserControlKS  5	   	        QLKhachSan.DatDichVuWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:QLKhachSan     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   /uc&clr-namespace:QLKhachSan.UserControlKS  5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $��2q�5   	   
����� � � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	     PhieuDatDichVuVM � DataContext# [ 5   	   $	��650��5   	   $	��900��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5   
   � $��0��6   .+�5       +   %QLKhachSan.UserControlKS.ControlBarUC  -   5          Name$ ucControlBar��5          
HeaderText$ Phiếu Dịch Vụ��64   5!      � 5#   
   $��1��6   	 � ColumnDefinitions	 5$      �� 5%      $
��auto �6#   62   �� 5&      6%   .+�5)      � $��0��6    5*      �� 5+      $
��auto �6$   64   �� 5,      $
��auto �6$   64   �� 5-      $
��auto �6$   64   �� 5.      $
��auto �6$   64   �� 5/      6&   .+�52      � $��1��6   .+�53      �� .+�54      �� $��
30,10,30,0q�6$   $��Tên dịch vụ:��68   $��15(�6L   6\   �� 55      -   5        
 ��Name$
 	TenDichVu��56      $��30,10,30,10q�57      $
��Left=�58      $	��245��59      $��60��6%   $��20(�61    " MaterialDesignOutlinedComboBox#��[ 5<       �� SelectedValue 5:      �� *TENDV+��5;      �� *TTENDV+.  (System.Windows.Interactivity.Interaction   Triggers 5=      /  )System.Windows.Interactivity.EventTrigger  5>   "      	EventName$ SelectionChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5?   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *ShowCommand+   CommandParameter 6\   ��  �� ElementName$ 	TenDichVu��5@   #   5B      5C      5D      � 5F      $��0��6   .+�5G      �� .+�5H      �� $��
30,30,30,0q�6$   $��Số phòng:��68   $��15(�6I   6Y   �� 5I      -   5        $
 SoPhong��5J      $��30,10,30,10q�5K      $
��Left=�5L      $	��245��5M      $��60��6%   $��20(�61   #��[ 5P       5N      �� *	SOPHONG+��5O      �� *
SSOPHONG+ 5Q        5R   "   $ SelectionChanged��61   . 5S   &      6<   �� *ShowCommand1+ 6]   �� $ SoPhong��5T   #   5V      5W      5X      � 5Z      $��3��6   .+�5[      �� .+�5\      �� $��
30,10,30,0q�6$   $��Mã phiếu dịch vụ:��68   $��15(�6Q   6a   �� 5]       �� 
IsReadOnly . $��
30,10,30,5q�6{   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�    ! MaterialDesignOutlinedTextBox#��[ 6�   ��6"   �� *MAPDV+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   5^      5_      � 5a      $��2��6   .+�5b      �� .+�5c      �� $��
30,10,30,0q�6$   $��Mã dịch vụ:��68   $��15(�6K   6[   �� 5d       . $��
30,10,30,5q�6z   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6"   �� *MADV+$ PropertyChanged=�$ TwoWay=�6�   5e      5f      � 5h      $��4��6   .+�5i      �� .+�5j      �� $��
30,10,30,0q�6$   $��Số lượng:��68   $��15(�6I   6Y   �� 5k      -   5        $
 SoLuong��5l      $��30,10,30,10q�5m      $
��Left=�5n      $	��245��5o      $��60��6%   $��20(�61   #��[ 5r       5p      �� *SLDV+��5q      �� *
LISTNUMBER+5s      5t      5u      5v      � 5x      $��1��6    5y      �� 5z      6&   �� 5{      $
��auto �6$   64   .+�5~      #  MaterialDesignThemes.Wpf.Card  $��0��6&   $��30q�63   .��5      �� $
��auto=�6#   $
��auto=�6F   .��5�      ��  J� RenderTransformOrigin$ 0.5,0.49&�6�   ��6#   �� *
ListCTPDV1+$ TwoWay=�$ PropertyChanged=� �� SelectedItem 6x   �� *SelectedItem+$ TwoWay=� �� View 5�      �� 5�   "   ! �� ColumnHeaderContainerStyle 5�   &   �� 5�   *   .�5�   .   ��  �� Property � �� �� Value$ 10q�6P   5�   +   .P�5�   &   �� $��Tên dịch vụ��65    �� Width$	 200��6J    �� DisplayMemberBinding 6V   �� *TENDV+6   �� 5�   &   $��Số lượng��65   $
 Auto��6G    6T   �� *SLDV+6|   �� 5�   &   $��Tổng tiền��65   $	 150��6H    6T   �� *GIA+ �� StringFormat$ 
{0:N0} VND��6�   5�   #   5�      5�      5�      � 5�      $��1��6   .+�5�      ��  �� Orientation$ 
Horizontal=�6!   $��Right=�6:   .+�5�      �� 
��� �|�
���   �$��20,20,20,40q�5�      $��20(�5�       " MaterialDesignRaisedDarkButton#��[ 5�      $	��120��5�      $��50��5�      $��_Thêm��5�      ��5�      �� *
AddCommand+5�      �� 5�      
�������
���   �$��20,20,20,40q�5�      $��20(�5�      #��[ 5�      $	��120��5�      $��50��5�      $��_Hủy��5�      ��5�      �� *CancelCommand+5�      �� 5�      
���  ��
���   �$��20,20,50,40q�5�      $��20(�5�      #��[ 5�      $	��120��5�      $��50��5�      $��_Xóa��5�      ��5�      �� *DeleteCommand+5�      5�      5�      5�      5�      5�      5�      