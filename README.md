# JSONProcessing
This is my fifth project, which was assigned as homework in university. The console application is stored in ConsoleApp, the class library in Library.
### Main Assignment
### Requirements for the class library
The class library must contain two classes:
1) Customer class representing the objects described in the JSON file of the job. The fields of the class
must be readable, but closed to writing. The class must contain a constructor to initialize its fields. Choose independently an identifier
class identifier that will logically describe the object and satisfy Microsoft naming rules.
2) Static class JsonParser, containing two static methods: WriteJson and ReadJson. These methods must use the data streams defined in the
System.Console to read and write data. The data is supplied in JSON format, it is forbidden to use any specialized libraries for their parsing.
3) Class implementations must not violate data encapsulation and the Single Responsibility Principle.
4) Hierarchies must not violate the Liskov Substitution Principle and are designed based on the Dependency Inversion Principle.
Inversion Principle.)
5) Class implementations must not violate data access, such as providing external references to fields or changing the state of an object without checks.
6) Library classes must be accessible outside the assembly.
7) Each non-static class (if any) must necessarily contain, among others, a parameterless constructor or equivalent descriptions that allow its direct invocation
or implicit invocation.
8) It is forbidden to modify the dataset for classes that are built based on a JSON representation from a job.
9) It is allowed to extend open behavior or add closed functional members of a class.
10) It is allowed to use your own (self-written) class hierarchies in addition to those proposed in the assignment, but the OOP principles requirements to them are preserved.
### Requirements for the console application
The console application uses the class library described above, using the methods of the
static class JsonParser retrieves data for a collection of objects of type Customer, the data
for the objects are obtained from JSON representations of the individual variant file. The type of the collection
for objects to choose independently.
The console application also provides an interface for the user to interact with the
data of the collection objects. The user should be able to submit data to the input using
using the standard System.Console input and output stream or using a file-based
streaming I/O.
#### The user shall be provided with an OSD menu with the following features:
1. Enter data via System.Console or provide a file path to read the data.
2. Filter the data by one of the fields. The fields for filtering are selected by the user.
When working with the program, it should be clear which field was selected for filtering.
3. sort the data by one of the fields. The user selects the field for sorting.
When working with the program, it should be clear which field was sorted by.
4. Output (save) the data to System.Console or a file. The user must be able to
the possibility to overwrite the file from which the data was read, or specify a new path to the file for writing.
to the file for writing.
