using System;
namespace Library;

/// <summary>
/// Класс MyType из условия.
/// </summary>
public class Customer
{
	private int customerId;

	public int CustomerId
	{
		get
		{
			return customerId;
		}
	}

    private string name;

    public string Name
    {
        get
        {
            return name;
        }
    }

    private string email;

    public string Email
    {
        get
        {
            return email;
        }
    }

    private int age;

    public int Age
    {
        get
        {
            return age;
        }
    }

    private string city;

    public string City
    {
        get
        {
            return city;
        }
    }

    private bool isPremium;

    public bool IsPremium
    {
        get
        {
            return isPremium;
        }
    }

    private string[] purchases;

    public string[] Purchases
    {
        get
        {
            return purchases;
        }
    }

    public Customer(
        int customerId, string name, string email, int age,
        string city, bool isPremium, string[] purchases
        )
    {
        this.customerId = customerId;
        this.name = name;
        this.email = email;
        this.age = age;
        this.city = city;
        this.isPremium = isPremium;
        this.purchases = purchases;
    }

    public Customer() { }
}