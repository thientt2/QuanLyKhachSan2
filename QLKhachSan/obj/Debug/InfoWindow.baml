   M S B A M L   `   `   `  ����E  AQLKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLKhachSan
QLKhachSan  5   	   C&clr-namespace:QLKhachSan.UserControlKSQLKhachSan.UserControlKS  5
   	       QLKhachSan.InfoWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:QLKhachSan     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   /uc&clr-namespace:QLKhachSan.UserControlKS  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $��InfoW��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $��2q�5   	   
����� � � 
ResizeMode$ NoResize=�5   	    
 InfoVM � DataContext# [ 5   	    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��630��5   	   $
��1000��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5!   
   � $��0��6   .+�5"      +   %QLKhachSan.UserControlKS.ControlBarUC  -   5          Name$ ucControlBar��5"         
HeaderText$ Thông tin phòng��64   5#      � 5%   
   $��1��6   	 � ColumnDefinitions	 5&      �� 5'      $
��auto �6#   62   �� 5(      6%   .+�5+      � .+�5,      �� $
��auto��6   $��10,20,10,30q�6*   $��20(�6?   .  (MaterialDesignThemes.Wpf.ColorZoneAssist
   
Background

 �   �   
Foreground
 �����   Mode$ Custom=�6�   $��Thông tin đặt phòng��6�     MaterialDesignCardGroupBox#��[ 6�   .��5-      � $��0,10,0,0q�6    5.      �� 5/      $
��auto �6,   6<   �� 50      $
��auto �6,   6<   �� 51      $
��auto �6,   6<   �� 52      6.   .+�55      � $��0��6   .+�56      �� .+�57   "   �� $��
30,10,30,0q�6,   $ ��Mã phiếu đặt phòng:��6@   $��15(�6[   6k   �� 58   "   -   5         ��Name$ MAPDP��58   *   $��30,10,30,10q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�    ! MaterialDesignOutlinedTextBox#��[ 6�   ��69   �� *MAPDP+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   59      5:      � 5<      $��3��6   .+�5=      �� .+�5>   "   �� $��
30,10,30,0q�6,   $*��$Thời gian trả phòng còn lại:��6@   $��15(�6d   6t   �� 5?   "   -   5        $ TimeLeft��5?   *    �� 
IsReadOnly . $��30,10,30,10q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6N   �� *RemainingTime+ �� StringFormat$ 
hh\:mm\:ss��6�   5@      5A      � 5C      $��1��6   .+�5D      �� .+�5E   "   �� $��
30,10,30,0q�6,   $��Ngày nhận:��6@   $��15(�6R   6b   (  "System.Windows.Controls.DatePicker  5F   "   {�.  $��
30,10,30,5q�6�   $	��245��6�   $��20(�6�    $  MaterialDesignOutlinedDatePicker#��[ 6�      SelectedDate 6-   �� *NGNHAN+$ PropertyChanged=�$ TwoWay=�6�   5G      5H      � 5J      $��2��6   .+�5K      �� .+�5L   "   �� $��
30,10,30,0q�6,   $��Ngày trả:��6@   $��15(�6Q   6a     5M   "   {�.  $��
30,10,30,5q�6�   $	��245��6�   $��20(�6�   #��[ 6�    6-   �� *NGTRA+$ PropertyChanged=�$ TwoWay=�6�   5N      5O      5P      5Q      5R      � 5T      $��1��6   .+�5U      �� $
��auto��6   $��10,20,10,30q�6*   $��20(�6?   

 �   �
 �����$ Custom=�6�   $��Thông tin khách hàng��6�   #��[ 6�   .��5V      � $��0,10,0,0q�6    5W      �� 5X      $
��auto �6,   6<   �� 5Y      $
��auto �6,   6<   �� 5Z      $
��auto �6,   6<   �� 5[      6.   .+�5^      � $��0��6   	 5_      �� 5`   "   $
��auto �63   6B   �� 5a   "   65   .+�5d      � $��0��6#   .+�5e   "   �� .+�5f   &   �� $��
30,10,30,0q�60   $��Họ và tên:��6D   $��15(�6V   6f   �� 5g   &   -   5        $ TenKhachHang��5g   .   $��30,10,30,10q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6D   �� *TENKH+$ PropertyChanged=�$ TwoWay=�.��6  .  (System.Windows.Interactivity.Interaction   Triggers 5h   *   /  )System.Windows.Interactivity.EventTrigger  5i   .      	EventName$ TextChanged��6=   .  (System.Windows.Interactivity.TriggerBase   Actions. 5j   2   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6H   �� *ShowCommand+   CommandParameter 6h   ��  �� ElementName$ TenKhachHang��5k   /   .��5l   B   5m   '   5|   #   5}      � 5      $��1��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��CCCD:��6D   $��15(�6Q   6a   �� 5�   &   -   5        $ SOCCCD��5�   .    . $��30,10,30,10q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6>   �� *SOCCCD+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      5�      � 5�      $��1��6   	 5�      �� 5�   "   $
��auto �63   6B   �� 5�   "   65   .+�5�      � $��0��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��Giới tính:��6D   $��15(�6V   6f   �� 5�   &    . $��
30,10,30,5q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6.   �� *
GIOITINH+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      � 5�      $��1��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��Ngày sinh:��6D   $��15(�6V   6f     5�   &   {�.  $��
30,10,30,5q�6�   $	��245��6�   $��20(�6�   #��[ 6�    61   �� *NGSINH+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      5�      � 5�      $��2��6   	 5�      �� 5�   "   $
��auto �63   6B   �� 5�   "   65   .+�5�      � $��0��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��Số điện thoại:��6D   $��15(�6Z   6j   �� 5�   &    . $��
30,10,30,5q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6.   �� *SDT+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      � 5�      $��1��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��Email:��6D   $��15(�6R   6b   �� 5�   &    . $��30,10,30,10q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6.   �� *EMAIL+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      5�      � 5�      $��3��6   	 5�      �� 5�   "   $
��auto �63   6B   �� 5�   "   65   .+�5�      � $��0��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��Quốc tịch��6D   $��15(�6U   6e   �� 5�   &    . $��
30,10,30,5q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6.   �� *
QUOCTICH+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      � 5�      $��1��6#   .+�5�   "   �� .+�5�   &   �� $��
30,10,30,0q�60   $��Địa chỉ:��6D   $��15(�6T   6d   �� 5�   &    . $��30,10,30,10q�6�   $
��Left=�6�   $	��245��6�   $��60��6�   $��20(�6�   #��[ 6�   ��6.   �� *DIACHI+$ PropertyChanged=�$ TwoWay=�6�   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      