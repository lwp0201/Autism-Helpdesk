   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:LoginPage	LoginPage  5   	       LoginPage.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:LoginPage     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��525��6)   .��5	      �� 
�������.+�5
   
   �� -   5         ��Name$ autismHeadline��5
      $��AUTISM HELPDESK��6,    �� TextAlignment$ Center=�6C   ���	#FFFFFF79 �� Padding$ 20q�6q   $��20(�6~   ���	#FFF40B4B6�   � 5   
   $
��0 50q�6    � ColumnDefinitions 5      �� 5      $
��0.5* �6#   �� 5      $��* �6#   .+�5      �� .+�5      �� -   5        $ username��5      $��User Name :��6.   $
��Bold"�6A   $ Center=�6S   $��16(�6j   �� 5      -   5        $
 pass��5      $��
Password :��6*   $
��Bold"�6<   $ Center=�6N   $��16(�6e   $
��0 30q�6s   5      �� 5      $��1��6   .+�5      �� -   5         ��Name$ usernameBox��5      $��4q�6/   
���   �$��2q�6O   
�������$	��300��6u   $
��Left=�6�   �� 5      -   5        $ passBox��5      $��4q�6+   
���   �$��2q�6K   
�������$
��0 25q�6q   $	��300��6   $
��Left=�6�   5      5      �� 5   
   -   5         ��Name$ loginButton��5      $��Login��6@   $��80��6P   $��5q�6[   ���	#FFFFFF79$��16(�6~   $��	345,0,0,0q�6�   ���	#FFF40B4B$
��Bold"�6�   5      5      