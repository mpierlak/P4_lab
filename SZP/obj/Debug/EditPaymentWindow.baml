   M S B A M L   `   `   `  ����>  :SZP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SZPSZP  5   	       SZP.EditPaymentWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:SZP     5   	     � Title$  EditPaymentWindow��5   	   $	��450��6#   $	��800��60   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $$��Wybierz płatność do edycji:��6   $��0��67   $��5q�6D   �� 5   
   -   5         ��Name$ PaymentComboBox��5      $��0��6,   $��5q�69   ��5      �� 5      .R�5      ��  �� Orientation$ Vertical=�6!   .+�5      �� $��5q�6A   ��6$   �� *DisplayText+6A   5      5      5      �� 5   
   $��Nowa kwota płatności:��6   $��2��61   $��5q�6>   �� 5    
   -   5         ��Name$ NewAmountTextBox��5       $��3��6,   $��5q�69   �� 5"   
   $��Nowa data płatności:��6   $��4��60   $��5q�6=   (  "System.Windows.Controls.DatePicker  5#   
   -   5          Name$ NewDatePicker��5#      $��5��6,   $��5q�69   �� 5%   
   -   5        $��Zapisz��5%      $��5��6"   $��
5,61,5,-51q�6/   6C   �� 5&   
   -   5        $��Anuluj��5&      $��5��6"   $��
5,91,5,-81q�6/   6C   5'      5(      