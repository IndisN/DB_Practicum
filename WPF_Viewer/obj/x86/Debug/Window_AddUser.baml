   M S B A M L   `   `   `  ����E  AWPF_Viewer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:WPF_Viewer
WPF_Viewer  5   	       WPF_Viewer.Window_AddUser   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   'myclr-namespace:WPF_Viewer     5   	     � Title$  	Add User:��5   	   $	��300��6   $	��300��6(    � 
ResizeMode$ NoResize=�5   -    � ShowInTaskbar .   � 	Resources 5      ��%    5      .��5	      � .+�5
   
   �� $
��Left=�6   $��	40,40,0,0q�6/   $
��Wrap=�6B   $��Name:��6V   $	��Top=�6c   $
��Bold"�6{   $��14(�6�   �� 5   
   $
��Left=�6   $��	40,70,0,0q�6/   $
��Wrap=�6B   $��Email:��6V   $	��Top=�6d   $
��Bold"�6|   $��14(�6�   �� 5   
   $
��Left=�6   $��
40,100,0,0q�6/   $
��Wrap=�6C   $��Birth date:��6W   $	��Top=�6j   $
��Bold"�6�   $��14(�6�   �� 5   
   $
��Left=�6   $��
40,130,0,0q�6/   $
��Wrap=�6C   $��Photo:��6W   $	��Top=�6e   $
��Bold"�6}   $��14(�6�   �� 5   
   -   5        $��FName��5   �   $
��Left=�6   $��23��6-   $��
120,40,0,0q�69    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   $��70��6y   ��5      ��    mvvm �� Source# [   �� Path$ NewUser.FirstName� �� Mode$ TwoWay=�6e   �� 5   
   -   5        $��LName��5   �   $
��Left=�6   $��23��6-   $��
195,40,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $��70��6y   ��5      �� # [  $ NewUser.LastName�$ TwoWay=�6d   �� 5   
   -   5        $��Email��5   �   $
��Left=�6   $��23��6-   $��
120,70,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $	��145��6y   ��5      �� # [  $ NewUser.Email�$ TwoWay=�6a   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��BDate��5   i   $
��Left=�6   $��120,100,0,0q�60   $	��Top=�6E   $	��145��6]      FirstDayOfWeek$ Monday=�6v   	   SelectedDate	 5      �� # [  $ NewUser.BirthDate�$ TwoWay=�6p   �� 5   
   -   5        $��Photo��5   v   $��Load...��6   $
��Left=�6#   $��120,130,0,0q�6>   $	��Top=�6S   $��70��6k   6�   �� 5   
   -   5        $	��img��5   p   $
��Left=�6   $	��100��6+   $��
40,160,0,0q�68   $	��Top=�6L   $	��100��6d   $
��Fill=�5   T   ��6   �� # [  $ NewUser.Photo�6T   �� 5   
   -   5        $��Accept��5      $
��Left=�6"   $��190,200,0,0q�6=   $	��Top=�6R   $��70��6j   ��5      �� # [  $ AddUser_comm�6U   5      5      