   M S B A M L   `   `   `  ����>  :SZP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SZPSZP  5   	       SZP.DeletePaymentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:SZP     5   	     � Title$  DeletePaymentWindow��5   	   $	��450��6%   $	��800��62   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5          Name$ PaymentDataGrid��5
         AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Payment ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	PaymentId+  5      $ Description��6%    6:   �� *Description+  5      $ Amount��6%    65   �� *Amount+  5      $
 Date��6%    63   �� *Date+  5      $ Customer ID��6%    6:   �� *
CustomerId+5      �� 5   
   -   5        $��Delete Selected Payment��5      $
��Left=�6U   $	��Top=�6p   $��310,160,0,0q�6�   �� 5   
   -   5         ��Name$ OkButton��5      $��OK��6#   $
��Left=�60   $��460,160,0,0q�6K   $	��Top=�6`   $��75��6x   6�   5      5      