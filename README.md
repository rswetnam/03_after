# 03_after

This is taken from the Pluralsight Course by Thomas Claudia Huber.

I am trying to use test-driven development to add a method to the DeskBooking class called CreateBooking. 
This would replace the Create class in the DeskBookingRequestProcessor method.

The reason for doing this is that I am trying to make the DeskBooking class more of a "rich" domain model 
following following the course by Vladimir Khorikov - 
https://app.pluralsight.com/library/courses/refactoring-anemic-domain-model/table-of-contents

My problem is that I keep getting the a null reference exception - and I can't figure out if this is from how I constructed the tests and/or
if it's because of my understanding of creating rich domain models.  
