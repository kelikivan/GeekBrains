   M S B A M L   `   `   `  ����E  AWpfProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:WpfProject.ControlsWpfProject.Controls  5   	   (    "WpfProject.Controls.EmployeeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:WpfProject.Controls     5   	     � Title$L  FДобавление/редактирование сотрудника��5   	   $	��350��66   $	��330��6C   .��5	      � -   5         �Name$ 	_mainGrid��5	      .+�5
   
   �� $��Фамилия:��6   $��	20,20,0,0q�6#   �� 5   
   -   5         ��Name$ _txtLastName��5      $��23��5      $��120,20,25,0q�6    �� TextWrapping$
 Wrap=�63   $	��Top=�6G   ��5   (   �� *
LastName+ �� Mode$ TwoWay=�5   G   �� 5   
   $��Имя:��6   $��	20,63,0,0q�6   �� 5   
   -   5        $ _txtFirstName��5      $��23��5      $��120,63,25,0q�6   $
 Wrap=�63   $	��Top=�6G   ��5   )   �� *	FirstName+$ TwoWay=�5   G   �� 5   
   $��Отчество:��6   $��
20,106,0,0q�6$   �� 5   
   -   5        $ _txtLPatronymic��5      $��23��5      $��120,106,25,0q�6   $
 Wrap=�64   $	��Top=�6H   ��5   +   �� *
Patronymic+$ TwoWay=�5   H   �� 5   
   $ ��Дата рождения:��6   $��
20,149,0,0q�6)   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ _dpBirthDate��5      $��25��5      $��120,149,25,0q�6!   $	��Top=�67      SelectedDateFormat$ Short=�6O      IsTodayHighlighted .    FirstDayOfWeek$ Monday=�6�   	   SelectedDate	 5   +   �� *	BirthDate+$ TwoWay=�5   �   �� 5   
   $��Отдел:��6   $��
20,197,0,0q�6!   �� 5   
   -   5        
 ��Name$
 _cbDepartments��5      $��23��5      $��120,197,25,0q�6   $	��Top=�65    �� SelectedItem 5   +   �� *
Department+ �� UpdateSourceTrigger$ PropertyChanged=�$ TwoWay=�5   5   �� 5   
   -   5         ��Name$ _btnOK��5      $
��ОК��6!    �� 	IsDefault . $��23��5      $��Stretch=�6   $��25,0,172,25q�6<   $��Bottom=�6Q   �� 5    
   -   5        $ 
_btnCancel��5       $��Отмена��6%    �� IsCancel . $��23��5!      $��Stretch=�6   $��172,0,25,25q�6;   $��Bottom=�6P   5"      5#      