   M S B A M L   `   `   `  ����H  DRevitTemplate, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:RevitTemplateRevitTemplate  5      !    RevitTemplate.view.MainPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:RevitTemplate     5        N� 
Background
  �����$	��410��5      $	��520��6,   .��5	      ��  �� Padding$ 10q�6   ._�5
   
   �� .+�5      �� $��60��6   
�����_� J� RenderTransformOrigin$ 0.5,0.5&�6<   .+�5      � -   5         �Name$ 
grdDetails��5      $y�Visible=�6,    � ColumnDefinitions 5      �� 5      $	��31* �6+   �� 5      $	��40* �6+    � RowDefinitions 5      �� 5      �� 5      .+�5      �� $��Current State:��6   $
��Bold"�66   $
��Left=�6H   $��0��6c   $��0��6p   $��90��6�   �� 5      -   5         ��Name$ lblCurrentState��5      $
��Bold"�6a   $
��Left=�6s   $��0��6�   $��1��6�   
���  ��$	��200��6�   ��65   �� *	StateName+ �� Mode$ OneWay=�6�   5      5       � 5      -   5          �Name$
 Main��5      $	��290��6"   	  � NavigationUIVisibility$	 Hidden=�6/   
�������$
��0,10q�6b   � 5      $��Bottom=�6    5       �� 5!      $��* �6'   �� 5"      $��* �6'   �� 5#      $��* �6'   �� 5$      $��* �6'   .+�5'      �� -   5        
 ��Name$
 	btnCreate��5'   =   $��0��6   $��2��6)   ��6Q   �� *CurrentState.NameRightButton+$ OneWay=���6�   �� *SubmitCommand+$ OneWay=��� 5)      -   5        $
 btnDatePassed��5)   >   $��2��6   $��2��6*   $��Cancel��6U   ��6f   �� *CancelCommand+$ OneWay=�5,      5-      5.      5/      