   M S B A M L   `   `   `  ����D  @LogInForm, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:LogInForm.ViewModelsLogInForm.ViewModels  5      3clr-namespace:LogInForm.ModelsLogInForm.Models  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5      !    LogInForm.Views.EditAbsence   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      T PCatel.Extensions.Controls, Version=4.5.4.0, Culture=neutral, PublicKeyToken=nullE ACatel.MVVM, Version=4.5.4.0, Culture=neutral, PublicKeyToken=null'catelhttp://catel.codeplex.com   5      0local"clr-namespace:LogInForm.ViewModels   5      -local2clr-namespace:LogInForm.Models   5      2sys&clr-namespace:System;assembly=mscorlib   5        � WindowStartupLocation$  CenterScreen=�5      $	��300��5	      $	��500��5
       � 
ResizeMode$ NoResize=�5       � 	Resources 5       �� 
TargetType �� Property �� Value��%  '��       �� 5   
   " ��6   .�5      ��  �@��TextAlignment$ Center=�5      �� 5       � ��$ 30(�5      �� 5       � �� �#4dd65f5      �� 5       � ��
 �   �5      �� 5       � ��$ 1q�5      5      5      .��5      � ���#009cad � RowDefinitions 5    
   �� 5!      $	��140 �6   �� 5"      $	��140 �6   �� 5#      $	��140 �6   �� 5$      $��* �6   .+�5'   
   �� $��0��6   .+�5)      �� $��Name:��6   $
��Bold"�5*      $
��Left=�5+      $	��Top=�5,      �� 5.      ���#00c9db$	��130��50      $	��290��51      $��Center=�52      $��Center=�53      ��5.      �� *Name+53      55      �� 57   
   $��1��6   $��0,0,0,5q�58      .+�5:      �� $��Abriviature:��6   $
��Bold"�5;      $
��Left=�5<      $	��Top=�5=      �� 5?      ���#00c9db$	��130��5A      $	��290��5B      $��Center=�5C      $��Center=�5D      ��5?      �� *Abriviature+5D      5F      �� 5H   
   $��2��6   $��0,0,0,5q�5I      .+�5K      �� $��Days:��6   $
��Bold"�5L      $
��Left=�5M      $	��Top=�5N      �� 5P      ���#00c9db$	��130��5R      $	��290��5S      $��Center=�5T      $��Center=�5U      ��5P      �� *Days+5U      5W      �� 5Y   
   $��3��6   $��Update��5Z      $
��Bold"�5[         CreateUpdateBtn#��[  5\      ��5]      �� *AddAbsenceCommand+5^      5_      