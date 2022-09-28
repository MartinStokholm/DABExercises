# Describtion of the system
A city hall in Denmark asked your start-up to develop a system to manage recreation facilities like Aarhus Kommune does (https://friluftslivaarhus.dk/). 
The systems **primary goal** is to **allow** the parks and recreation personnel to **manage the public use of available facilities** and to **allow citizens** to get **information** about and **booking of facilities**.

The municipality must keep track of **which facilities exist** and the system is expected to provide a **public listing of all the facilities available to citizens**. 
Each facility belongs to a certain **kind** (e.g: fireplace, shelter, educational centers, etc.), has a **closest/nærmeste address**, and there is a **description** that must be shown to citizens with **information** about the **facility**, and what **items** are available at location (e.g.: projector, cooking utensils, boards,... ), its **usage rules** (e.g.: maximum occupants). 

**Some facilities are used as a first come first served approach, some may be reserved by users.**

Citizens must be able to register as **users**, by providing a **name**, **phone number**, **email**, and a **category** (e.g: private person, recreational association, business). 
In addition, at registration, citizens may provide a **CVR number** if they are registering on behalf of a recreational association, but must provide a CVR if they are registering on behalf of a business.

Users must be able to book **facilities** for an **activity**. 
When booking an activity, the user must provide an interval of contiguous **hour slots** and the **number of participants** taking part in the activity. 
The user may add a **note** to the booking to communicate with the parks and recreation personnel. 
Some facilities can only be booked by a certain category of users, e.g.: a certain educational center may only be booked by businesses, schools or associations. 
Also, during a booking a user may upload a document which proves that the reservation is being done on behalf of an authorised category of users.

The city hall personnel wants to have access to all the reservations and periodically may check reserved facilities to ensure the maximum number of occupants is being respected and to perform maintenance of the available items. 
Available items may be require periodic maintenance, and the system must allow personnel to check the history of **maintenance interventions**. Each maintenance intervention has a **date** and a **description**.

Optional: Enrich your model to match the Aarhus Kommune (https://friluftslivaarhus.dk/) service.

Your task is now to design, implement and use a relational database that could support this system.

# What must be handed in:
All SQL should be compatible with Transact-SQL for Microsoft SQL Server 2019.

1. E/R diagram of the system (.png/.pdf)

2. SQL artifacts as follows, where standard file extension is *.sql :
   - Logical Schema for creating database, tables and relationships, where database name must contain your au-id.     
   - SQL for inserting dummy data, ie. schema for loading initial data into the database.
   - SQL for browsing data. Minimum queries to be done:
     - Get all available facilities names and closest/"nærmeste" address
     - Get all facilities as a table of names and address grouped by their kind
     - Get a list of booked facilities (name, location), with the booking user (and possible business) and the timeslot it is booked in.

3. A single page PDF containing reasoning about your final design if these are not apparent in E/R diagram (This may be your "can and must" statements)

# Hand In formalia:
All the above artifacts should be packed into a zip file named 'dab1-e22-<au-id>.zip NOT rar, 7z or something else. Example dab1-e22-au123456.zip

This hand in should be done individually and uploaded at Brightspace before deadline.
On the deadline day, the instructors will go around and expect to be shown an execution on your local machine of 2.2, 3.1, 3.2 and 3.3.
    - The assignment is graded by:
        - 0 (zero) Assignment is not accepted.
        - Missing deadline gives grade 0 whatever is handed ind. In case of problems, contact instructors well in advance.
        - A timely submitted assignment solution that is not approved (ie is graded 0)  will be given one more try. Deadline and scope of the new solution is given by educators.

Second try that does not achieve the grade 1 or 2 or is not handed in on time, will basically grade the solution 0 (zero).
    1 (one) Assignment approved with an acceptable solution. Solution has room for improvements and/or has some minor errors
    2 (two) Assignment as nearly perfect or perfect
    If your  Assignment 1 Modelling ends up with grade 0 (Zero) the E22-SW4DAB course is then "Ikke bestået" as all three assignments in course must be approved. 