   M S B A M L   `   `   `  ����J  FRoyT.TimePicker, Version=0.5.0.0, Culture=neutral, PublicKeyToken=nullJ6clr-namespace:RoyT.TimePicker;assembly=RoyT.TimePickerRoyT.TimePicker  5      = 9AA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:AA.ViewAA.View 5         AA.View.InsertVol   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Etp6clr-namespace:RoyT.TimePicker;assembly=RoyT.TimePicker     5      'localclr-namespace:AA.View     5        N� Title$  	InsertVol��5
      .��5      �  � DataContext 6   �� *.+.+�5   
   �� $��	50,25,0,0q�6   .+�5      �� $��Avion��6   $
��Left=�6$   $	��Top=�6?   $	��250��6W   6e   �� 5      -   5         ��Name$ avion��5       �� DisplayMemberPath$ MatriculeProperty��6&   $
��Left=�6L   $	��Top=�6g   $	��100��6   6�   �� 5      $��Aéroport départ��6   $
��Left=�6.   $	��Top=�6I   $	��250��6a   6o   �� 5      -   5        $ 	aeroportd��5      $ LibelleProperty��6*   $
��Left=�6N   $	��Top=�6i   $	��100��6�   6�   �� 5      $��Aéroport arrivée��6   $
��Left=�6/   $	��Top=�6J   $	��250��6b   6p   �� 5      -   5        $ 	aeroporta��5      $ LibelleProperty��6*   $
��Left=�6N   $	��Top=�6i   $	��100��6�   6�   �� 5      $��Heure Départ��6   $
��Left=�6+   $	��Top=�6F   $	��250��6^   6l   &    RoyT.TimePicker.TimePickerSlider  5      -   5          Name$ heureD��5   "   $
��Left=�62   $	��Top=�6M   $	��200��6e      Time 6q   �� *heureD+ �� Mode$ TwoWay=�   MinTime 6�   �� *	MinTime+   MaxTime 6�   �� *	MaxTime+�� 5      $��Heure Arrivée��6   $
��Left=�6,   $	��Top=�6G   $	��250��6_   6m     5      -   5        $ heureA��5   "   $
��Left=�62   $	��Top=�6M   $	��200��6e    6q   �� *heureA+$ TwoWay=� 6�   �� *	MinTime+ 6�   �� *	MaxTime+�� 5       $��Date départ��6   $
��Left=�6*   $	��Top=�6E   $	��250��6]   6k   (  "System.Windows.Controls.DatePicker  5!      -   5        	  Name$	 dateD��5!      $
��Left=�6?   $	��Top=�6Z   $	��100��6r   
   Text
 6(   �� *dateD+6r   �� 5#      $��Date arrivée��6   $
��Left=�6+   $	��Top=�6F   $	��250��6^   6l     5$      -   5        $	 dateA��5$      $
��Left=�6?   $	��Top=�6Z   $	��100��6r   
 6(   �� *dateA+6r   �� 5&      $��Lieu Départ��6   $
��Left=�6*   $	��Top=�6E   $	��250��6]   6k   �� 5'      -   5         ��Name$ lieuD��5'      $
��Left=�6<   $	��Top=�6W   $	��100��6o   ��6%   �� *lieuD+6o   �� 5)      $��Lieu Arrivée��6   $
��Left=�6+   $	��Top=�6F   $	��250��6^   6l   �� 5*      -	   5        $ lieuA��5*      $
��Left=�6<   $	��Top=�6W   $	��100��6o   ��6%   �� *lieuA+6o   �� 5,      $��	Passagers��6   $
��Left=�6(   $	��Top=�6C   $	��250��6[   6i   �� 5-      -
   5        $ 
nbPassager��5-      $
��Left=�6F   $	��Top=�6a   $	��100��6y   ��6*   �� *
nbPassager+6y   �� 5/      -   5        $��Valider��5/      ���#ff4500���#ff4500$��0,30,0,0q�6R   $	��Top=�6�   $
��Left=�6�   50      51      54      