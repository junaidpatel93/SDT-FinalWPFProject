   M S B A M L   `   `   `  ����E  ABookMyShow, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:BookMyShow
BookMyShow  5          BookMyShow.ShowEntry   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:BookMyShow     5        N� Title$  
Show Entry��5	      $	��819��6    � 	Resources 5
         BookMyShow.Cities 
  Cities   BookMyShow.City   Name	   Id"   BookMyShow.SeatClassDataList  seatClassDataList   BookMyShow.SeatClassData   Name	   Id    BookMyShow.NumberConverter  numberConverter   BookMyShow.NameConverter  nameConverter   BookMyShow.ShowTimeList  ShowTimeList   BookMyShow.ShowTime   Name	   Id��%�  &	        &	 �     &	 h    &	 {    &	 �      5   
     5      $ 	Kitchener��6   $ 0��6*     5      $ Waterloo��6   $ 1��6)     5      $ 	Cambridge��6   $ 2��6*   5        5   
     5      $ Silver Class ($10)��6"   $ 0��6<     5      $ Gold Class ($15)��6"   $ 1��6:     5      $ Platinum Class ($20)��6"   $ 2��6>   5        5   
   6      5   
   6     5   
     5      $ 10 AM��6   $ 0��6*     5      $
 2 PM��6   $ 1��6)     5      $
 5 PM��6   $ 2��6)     5      $
 9 PM��6   $ 2��6)   5      5      .��5      � .+�5   
   �� .+�5       �� -   5        $��lblTitle��5       $��Ticket Booking System��6$    �� Left$	 289��6D   $	��246��6V   $
��Bold"�6b   $��18(�6t   
	 �� Top$	 2��6�   �� 5"      -   5        $��lblGenre��5"      $��Genre��6$   $	 199��64   $	 50��6F   $��14(�6V   �� 5#      -   5        $��comboBoxGenre��5#      $	 268��6,   $	 50��6>   $��24��6N   $	��160��6Z   
 �� DisplayMemberPath$

 Name��6�   $ �� IsSynchronizedWithCurrentItem$
 TrueY�6�   $��14(�6�   ��6f   ��  �� Path$ Genres�5$      �� 5%      -   5        $��lblErrorGenre��5%      $��Please select genre.��6)   $	 428��6H   $	 48��6Z   
���  ��$
��Bold"�6{   $	��303��6�   $y�Hidden=�6�   �� 5'      -   5        $��lblMovie��5'      $��Movie��6$   $	 198��64   $	 96��6F   $��14(�6V   �� 5(      -   5        $��comboBoxMovie��5(      $	 268��6,   $	 96��6>   $��24��6N   $	��160��6Z   $

 Name��6�   $
 trueY�6�   $��14(�6�   ��6f   �� $ Genres/Movies�5)      �� 5*      -   5        $��lblErrorMovie��5*      $��Please select movie.��6)   $	 428��6H   $	 96��6Z   
���  ��$
��Bold"�6{   $	��301��6�   $y�Hidden=�6�   �� 5,      -   5        $��lblShowTime��5,      $��	Show Time��6'   $	 168��6;   $		 140��6M   $��14(�6^   �� 5-      -	   5        $��comboBoxShowTime��5-      $	 268��6/   $		 140��6A   $��24��6R   $	��160��6^   $

 Name��5.   U    �� SelectedValuePath$
 Name��6n   $��14(�5/   <   ��5.      ��  �� Source# [ 50      �� 51      -
   5        $��lblErrorShowTime��51      $��Please choose show time.��6,   $	 428��6O   $		 140��6a   
���  ��$
��Bold"�6�   $	��301��6�   $y�Hidden=�6�   �� 54      -   5        $��
lblShowDay��54      $��Show Day��6&   $	 175��69   $		 186��6K   $��14(�6\   �� 55      -   5        $��comboBoxShowDay��55      $	 268��6.   $		 186��6@   $��24��6Q   $	��160��6]   $��14(�6�   56      �� 57      -   5        $��lblErrorShowDay��57      $��Please choose show day.��6+   $	 428��6M   $		 186��6_   
���  ��$
��Bold"�6�   $	��381��6�   $y�Hidden=�6�   �� 59      -   5        $��lblNumberOfSeat��59      $��Number of Seat��6+   $	 139��6D   $		 231��6V   $��14(�6g   �� 5:      -   5        $��txtBoxNumberOfSeat��5:      $��24��60   $	��160��6<   $	 268��6H    �� TextWrapping$
 Wrap=�6Z    �� TextAlignment$ Right=�6n   $		 231��6�   $��14(�5<   s   ��5;      �� $ TicketData.NumberOfSeat� �� 	Converter# [  � ToolTip 5<      ��  �� ElementName$ txtBoxNumberOfSeat��$) #(Validation.Errors)[0].ErrorContent�.��6�   ��5=      �� 5>      $ TicketData.NumberOfSeat�6    �� NotifyOnValidationError .  �� ValidationRules 5?      	  BookMyShow.NumberRule	  5@      
 	  Min$ 1��6/   
 	  Max$ 6��67   5B      .��5C       5D      �� 5E      -   5        $��lblErrorNumberOfSeat��5E      $7��1Please enter the number of seat. Range from (1-6)��60   $	 428��6l   $		 231��6~   
���  ��$
��Bold"�6�   $	��301��6�   $y�Hidden=�6�   �� 5G      -   5        $��lblSeatClass��5G      $��
Seat Class��6(   $	 168��6=   $		 276��6O   $��14(�6`   �� 5H      -   5        $��comboBoxSeatClass��5H      $	 268��60   $		 276��6B   $��24��6S   $	��160��6_   $

 Name��6�   $
 Name��6�   $��14(�6  ��6k   �� # [ 6  �� 5I      -   5        $��lblErrorSeatClass��5I      $��Please select seat class.��6-   $	 428��6Q   $		 276��6c   
���  ��$
��Bold"�6�   $	��286��6�   $y�Hidden=�6�   �� 5K      -   5        $��lblName��5K      $��	Your Name��6#   $	 168��67   $		 321��6I   $��14(�6Z   �� 5L      -   5        $��
txtBoxName��5L      $��24��6(   $	��160��64   $	 268��6@   $
 Wrap=�6R   $		 321��6f   $��14(�5O   5   ��5M      �� $ TicketData.Name�# [  5N      �� $ 
txtBoxName��$) #(Validation.Errors)[0].ErrorContent�.��5O   C   ��5P      �� 5Q      $ TicketData.Name�6    .  5R      
   BookMyShow.NameRule
  5S      5U      .��5V       5W      �� 5X      -   5        $��lblErrorName��5X      $<��6Please enter your name. Length is more than two words.��6(   $	 428��6i   $		 321��6{   
���  ��$
��Bold"�6�   $	��333��6�   $y�Hidden=�6�   $��27��6�   �� 5Z      -   5        $��lblCity��5Z      $
��City��6#   $	 212��62   $		 365��6D   $��14(�6U   �� 5[      -   5        $��comboBoxCity��5[      $	 268��6+   $		 365��6=   $��24��6N   $	��160��6Z   $

 Name��6�   $
 Name��6�   $��14(�6�   ��6f   �� # [  6�   �� 5\      -   5        $��lblErrorCity��5\      $��Please select the city.��6(   $	 428��6J   $		 365��6\   
���  ��$
��Bold"�6~   $	��148��6�   $y�Hidden=�6�   �� 5^      -   5        $��btnBook��5^      $
��Book��6$   $	 149��63   $		 421��6E   $��40��6V   $	��185��6b   $��14(�6�   ���	#FFDDDDDD6�   �� 5_      -   5        $��btnCheckDetail��5_      $��Check Details��6+   $	 388��6C   $		 421��6U   $��40��6g   $	��185��6s   $��14(�6�   �� 5a      $��/image/sidebar_img.png��6   $	��170��64   $		 307��6A   $	��142��6R   $ 2��6^   5b      5c      5d      