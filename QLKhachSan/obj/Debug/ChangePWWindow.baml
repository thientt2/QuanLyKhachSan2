   M S B A M L   `   `   `  ����E  AQLKhachSan, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:QLKhachSan
QLKhachSan  5   	   C&clr-namespace:QLKhachSan.UserControlKSQLKhachSan.UserControlKS  5	   	       QLKhachSan.ChangePWWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:QLKhachSan     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   /uc&clr-namespace:QLKhachSan.UserControlKS  5	   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
   	   -   5        $��changePWWindow��5   	      MaterialDesignBody#���   5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	   $��2q�5   	   
����� � � 
ResizeMode$ NoResize=�5   	    � WindowStyle$
 None=�5   	     
ChangePWVM � DataContext# [ 5   	    � WindowStartupLocation$ CenterScreen=�5   	   $	��520��5   	   $	��550��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      6   .+�5"   
   � $��0��6   .+�5#      +   %QLKhachSan.UserControlKS.ControlBarUC  -   5          Name$ ucControlBar��5#         
HeaderText$ Đổi Mật Khẩu��64   5$      � 5&   
   $��1��6   .+�5'      �� $��30q�6   .+�5(      �� $��Nhập mật khẩu cũ:��6   $��40,10,10,10q�65   $��20(�6J   �� 5*      $��60��5+      $��	40,0,40,0q�5,      $��Bottom=�5-      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$	 Mật khẩu cũ��5.      
 �� AcceptsReturn
 . $��20(�50       ! MaterialDesignOutlinedTextBox#��[ 52       �� TextWrapping$
 Wrap=�53      " �� VerticalScrollBarVisibility$
 Auto=�54      ��51      �� *OldPassword+54      �� 57      $ ��Nhập mật khẩu mới:��6   $��40,10,10,10q�66   $��20(�6K   �� 59      $��60��5:      $��	40,0,40,0q�5;      $��Bottom=�5<      $	 Mật khẩu mới��5=      
 . $��20(�5?      #��[ 5A      $
 Wrap=�5B      $
 Auto=�5C      ��5@      �� *NewPassword+5C      �� 5E      $&�� Nhập lại mật khẩu mới:��6   $��40,10,10,10q�6:   $��20(�6O   �� 5G      $��60��5H      $��	40,0,40,0q�5I      $��Bottom=�5J      $	 Xác nhận mật khẩu��5K      
 . $��20(�5M      #��[ 5O      $
 Wrap=�5P      $
 Auto=�5Q      ��5N      �� *ConfirmPassword+5Q      �� 5S      $��Xác nhận��6    �� 	IsDefault .  # MaterialDesignRaisedLightButton#��[ 5W      $	��130��5X      $��40��6!   $��Right=�6-   $��30q�6I   ��5U      �� *ConfirmCommand+��5V      ��  �� ElementName$ changePWWindow��5X   I   5Y      5Z      5[      5\      