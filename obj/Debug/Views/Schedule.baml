   M S B A M L   `   `   `  ����D  @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels  5          LogInForm.Views.Schedule   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      0local"clr-namespace:LogInForm.ViewModels   5      -   5          Catel.Windows.Window   Name$  scheduleWindow��5
       � WindowStartupLocation$ CenterScreen=�5      $	��700��5      $	��700��5       � 
ResizeMode$ NoResize=�5	       � 	Resources 5      -   'LogInForm.ViewModels.CellStyleConverter   cellStyleConverter  createButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value �� 
TargetName  
saveButton  printButton  deleteButton3   -LogInForm.ViewModels.ShiftVisibilityConverter  visibilityConverter  shiftButtons:  4System.Windows.Controls.Primitives.DatePickerTextBox ��Name �� Path �� StringFormat �� RelativeSource �� AncestorType(  "System.Windows.Controls.DatePicker��%   &	        &	      &	     &	     &	 �    &	 �    &	 
    '  �	      5   
   6#   �� 5   
   " ��5      .�5      ��  � ��$ 70��5      �� 5       � ��$ 35��5      �� 5       � ��$ 0,0,20,0q�5      �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $	 Btn��5   !   $	 20��5   !   ���#00bed3._�5      �� $��Center=�6/   $��Center=�5   /   5       
 5!      P� 5"       �@J�IsMouseOver . . �5$   "   �� $	 Btn��6)    � �� �#009cad5&   )   5'      5>      5@      5A      �� 5D   
   " ��5E      .�5F      ��  � ��$ 70��5G      �� 5H       � ��$ 35��5I      �� 5J       � ��$ 0,0,20,0q�5K      �� 5L       � �� 5M      �� 5N      " ��6&   .R�5O      �� $	 Btn��5P   !   $	 20��5O   !   ���#00db20._�5R      �� $��Center=�6/   $��Center=�5S   /   5T      
 5U      P� 5V       �@J�IsMouseOver . . �5X   "   �� $	 Btn��6)    � �� �#00af1a5Z   )   5[      5_      5a      5b      �� 5e   
   " ��5f      .�5g      ��  � ��$ 70��5h      �� 5i       � ��$ 35��5j      �� 5k       � ��$ 0,0,20,0q�5l      �� 5m       � �� 5n      �� 5o      " ��6&   .R�5p      �� $	 Btn��5q   !   $	 20��5p   !   ���#fc6c44._�5s      �� $��Center=�6/   $��Center=�5t   /   5u      
 5v      P� 5w       �@J�IsMouseOver . . �5y   "   �� $	 Btn��6)    � �� �#DA542D5{   )   5|      5�      5�      5�      �� 5�   
   " ��5�      .�5�      ��  � ��$ 70��5�      �� 5�       � ��$ 35��5�      �� 5�       � ��$ 0,0,20,0q�5�      �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $	 Btn��5�   !   $	 20��5�   !   ���#ff1905._�5�      �� $��Center=�6/   $��Center=�5�   /   5�      
 5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $	 Btn��6)    � �� �#D215025�   )   5�      5�      5�      5�        5�   
   6)   �� 5�   
   " ��5�      .�5�      ��  � ��$ 70��5�      �� 5�       � ��$ 70��5�      �� 5�       � ��$ 5q�5�      �� 5�       � �� 5�      �� 5�      " ��6&   .R�5�      �� $	 Btn��5�   !   $	 20��5�   !   ���#00af1a._�5�      �� $��Center=�6/   $��Center=�5�   /   5�      
 5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $	 Btn��6)    � �� �#00db205�   )   5�      5�      5�      5�      �� 5�   
   "  6   .�5�      ��  � �� 5�      �� 5�      .R�5�      �� $ PART_TextBox��6"   ��5�   "   �� $ SelectedDate�$ 
dd MM yyyy�� �� "  5�      5�      5�      5�      .��5�      � ���#D9234C � RowDefinitions 5�   
   �� 5�      $��50 �6   �� 5�      $	��150 �6   �� 5�      $	��150 �6   �� 5�      $��* �6   .+�5�   
   � $��0��6   .+�5�      �� $��40��5�      $��30��5�      $
��Left=�5�      $��Center=�5�      ��5�      �� *MonthsRange+ �� SelectedItem 5�      �� *SelectedMonth+5�      �� 5�      $��70��5�      $��30��5�      $��Right=�5�      $��Center=�5�      $��0,10,574,11q�5�      ��5�      �� *
YearsRange+ 5�      �� *SelectedYear+5�      �� 5�      $
��View��6   #��[ 5�      $
��Left=�5�      $��	130,0,0,0q�5�      ��5�      �� *ApplyCommand+5�      �� 5�      $
��Save��6   #��[ 5�      $
��Left=�5�      $��	250,0,0,0q�5�      ��5�      �� *SaveCommand+5�      �� 5     $��Print��6   #��[ 5     $
��Left=�5     $��	330,0,0,0q�5     ��5     �� *PrintCommand+5     �� 5      �� SelectedIndex$ 0��5     $	��150��5     $��Right=�5     $��Center=�5     $��	0,0,110,0q�5     ��5     �� *EmployeesWithNoSchedule+ 5	     �� *SelectedEmployee+y�5
     �� *IsVisibleAfterApply+ �� 	Converter# [ ��5     �� 5     .R�5     ��  �� Padding$ 5q�6!   $	��100��5  !   $��30��5  !   $��Center=�5  !   ._�5     ��  �� TextAlignment$ Center=�6(   $��Center=�5  (   $��Center=�5  (   ��5  (   �� *FullNameOneLine+5     5      5$     �� 5&     $	��Add��6   #��[ 5'     $��Right=�5)     ��5(     �� *AddEmployeeSchedule+5)     5+     � 5.  
   $��1��6    � ColumnDefinitions 50     �� 52     $��* �6#   �� 53     $��* �6#    57     �� 58     $��30 �6    �� 59     $��* �6    .+�5<     �� $��0��6   $��0��5=     $��Shifts��5>     $
��Bold"�5?     $��Center=�5@     $	��Top=�5A     y�5B     �� *IsVisibleAfterApply+# [ �� 5D     $��0��6   $��1��5E     $��Stretch=�5F     $��Stretch=�5G     ���#D9234Cy�5I     �� *IsVisibleAfterApply+# [ ��5J     �� *Shifts+��5L     �� 5M     .R�5N     �  � Orientation$ 
Horizontal=�6$   $
��Auto=�5O  $   $
��Auto=�5P  $   ���#D9234C5Q  $   5R     ��5V     �� 5X     .R�5Y     �� #��[ 5[  !   $��5q�5\  !   ��5Y  !   ��  �� ElementName$ scheduleWindow��$&  DataContext.SelectedShiftCommand���5Z  !   �� ��5^     �� 5`  "   ��6,   �� *Name+5b  #   5d     5e     5h     5i       5l  
   $��1��6   $��2��5m     $	��200��5n     $	��Top=�5o     $��Right=�5p     $��	0,30,50,0q�5r      � Cursor$
 Hand��5s        IsTodayHighlighted .    SelectedDateFormat$ Short=�5u        FirstDayOfWeek$ Monday=�5y     y�5q     �� *IsVisibleAfterApply+# [     SelectedDate  5v     �� *SelectedDate+!   DisplayDateStart! 5w     �� *FirstDayOfMonth+"   DisplayDateEnd" 5x     �� *LastDayOfMonth+5y     � 5{  
   $��2��6   y�5|     �� *IsVisibleAfterApply+# [  5~     �� 5�     $��* �6#   �� 5�     $��* �6#    5�     �� 5�     $��30 �6    �� 5�     $��* �6    .+�5�     �� $��0��6   $��0��5�     $��Absences��5�     $
��Bold"�5�     $��Center=�5�     $	��Top=�5�     �� 5�     $��2��6   $��0��5�     $��Stretch=�5�     $��Stretch=�5�     ���#D9234C��5�     �� *
Absences+��5�     �� 5�     .R�5�     � $ 
Horizontal=�6$   $
��Auto=�5�  $   $
��Auto=�5�  $   ���#D9234C5�  $   5�     ��5�     �� 5�     .R�5�     �� #��[ 5�  !   $��5q�5�  !   ��5�  !   �� $ scheduleWindow��$( "DataContext.SelectedAbsenceCommand���5�  !   �� ��5�     �� 5�  "   ��6,   �� *Name+5�  #   5�     5�     5�     5�     �� 5�  
   $��3��6   ��5�     �� *EmployeesWithSchedule+y�5�     �� *IsVisibleAfterApply+# [ ��5�     �� 5�     .R�5�     � $ 
Horizontal=�6    $
��Auto=�5�      $
��Auto=�5�      $	��690��5�      ���#D9234C5�      5�     ��5�     �� 5�     .R�5�     9� $	��200��5�     $	��300��5�     $��10q�5�     ��5�     �� ��5�     �� 5�     .R�5�  "   �� # �� Orientation$# 
Horizontal=�6-   .+�5�  &   �� $��5q�5�  /   $ d� 	IsChecked$ 5�  /   �� *DataContext.IsSelected+ �� *FindAncestor+$ ExpanderL�5�  /   �� 5�  &   $��5q�5�  0   ��5�  0   �� *$"DataContext.MonthTotalWorkingHours+ �� *FindAncestor+$ ExpanderL�5�  0   �� 5�  &   $��5q�5�  0   ��5�  0   �� *DataContext.FullNameOneLine+ �� *FindAncestor+$ ExpanderL�5�  0   5�  #   5�     ��5�     �� 5�     .R�5�  "   &   System.Windows.Controls.DataGrid  %   AutoGenerateColumns% .  $��Visible=�5�  +   &   
IsReadOnly& . '   CanUserSortColumns' .  (   CanUserReorderColumns( .  )   CanUserResizeRows) .  *   CanUserResizeColumns* .  ��5�  +   �� *ShiftsAndAbsences++   Columns+ 5�  &   0  *System.Windows.Controls.DataGridTextColumn  5�  *   ,  &System.Windows.Controls.DataGridColumn,   Header$
, Data��6=   -   Width5	  /System.Windows.Controls.DataGridLengthConverter$- 75	 5�  =   1
  +System.Windows.Controls.DataGridBoundColumn. 
  Binding. 5�  =   �� *
DayOfUse+$ {0:dd.MM.yyyy}��  5�  *   $	, Abr��6=   $- 50	 5�  =   . 5�  =   �� *Abriviature+/   	CellStyle/ 5�  .   �� 5�  2   *  $System.Windows.Controls.DataGridCell"  68   .�5�  6   ��  � �� 5�  =   �� *AttendanceType+# [  5  3   5  +     5  *   $, Hours��6=   $- 45	 5  =   . 5  =   �� *WorkingHoursForTable+5  #   5     5     5     5     5     5     