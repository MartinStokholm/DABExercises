## 1) Consolidation
The first part of the assignment is a review and consolidation exercise. In you group, you should review each others' Assignment 1 so you combine the different solutions into a single, improved, and coherent joint model*.

This should end up with a consolidated model, which you need to draw in an E/R diagram** and a short text explaining why you have discarded and keep the things from your previous individual solutions.

**Deliverable**: One PDF with an E/R diagram and review of the 2-4 models you started with. The file should named DAB_2_Model_1_grp<grp-no>.pdf (e.g. DAB_2_Model_1_grp42.pdf)

* Note: This will also give you peer feedback on Assignment 1, so if you need/want to redo anything take this last chance to improve and resubmit your previous hand-in.

** IMPORTANT: Only diagrams in Chen notation will be accepted at full grade. A comparison of notations is available in here. Please do not use UML or IE,...

## 2) Entity Framework Core
The second part of the assignment is to implement the model obtained above in an Entity Framework Core .NET 6 solution. This can either be a Console application or an ASP.NET application.

From your application it should be possible to query the database with the queries from Assignment 1:

- Get all available facilities names and closest/"nærmeste" address
- Get all facilities as a table of names, address and kind ordered by their kind. (Alternatively: Get the number of facilities grouped by their kind)
- Get a list of booked facilities name with the booking user (and possibly business) and the timeslot it is booked in.

The results can be obtained either as a console dump from selecting each option from a simple menu in your console application, or a json dump obtained by a call to the REST interface in your ASP.NET solution.

You solution should have a way to seed the database with dummy data, either with HasData or as part of the application's startup. If we need extra data we will just use the database, so no need to make CREATE/UPDATE endpoints.
**Deliverable**: As part of 4)

## 3) New requirements
In this part we will change the E/R model. At this point you already developed a working solution to the customer, but of course before we can release this to Brightspace, the customer has asked some small changes (features).

- The new municipalities want to replace the "nærmest address" with an actual GPS coordinates for the Facility
- The new municipalities are more strict and require every participant CPR to be included in a booking.
    - In addition to the previous queries there is a query no. 4 that shows for each booking the CPR numbers of the participants.
- In addition to the previous queries there is a query no. 5 that provides the history of maintenance interventions.

**Deliverable**: One PDF with an updated E/R diagram. The file should named DAB_2_Model_2_grp<grp-no>.pdf (e.g. DAB_2_Model_2_grp42.pdf)

## 4) Updated solution
In this last part you will implement the changes defined in your solution to 3) into your EFCore project for number 2). This should be achieved using the EFCore migrations feature. We expect to see one migration for each above feature and recommend you name them 'Migration1', 'Migration2' and 'Migration3'.

Hand-in: A cleaned and zipped .NET 6 Solution into a filed named DAB_2_Solution_grp<grp-no>.zip (e.g. DAB_2_Solution_grp42.zip)