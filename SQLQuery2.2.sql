select Guest.name 
From Guest , Hotel , Booking 
where Hotel.Name ='prinsden'
And hotel.Hotel_No= booking.Hotel_No
And Date_To>= Convert ( datetime, '2011-02-14')
And booking.Guest_No= guest.Guest_No
