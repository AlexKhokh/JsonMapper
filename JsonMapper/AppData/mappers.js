
function Default(context)
{
	var json=JSON.parse(context);
	var result = new BasePolicy();
	result.Vehicle = new Vehicle();
	result.Insurer = new Person();
	result.Insurer.Name = json.Insurer.Name;	
	result.Vehicle.Model = json.Vehicle.Model;
	result.Vehicle.Mark = json.Vehicle.Mark;	
	result.EffectiveDate = json.EffectiveDate;
	result.ExpirationDate = json.ExpirationDate;	
	return result;
}

function MapperOne(context)
{
	//debugger;
	var json=JSON.parse(context);
	var result = new BasePolicy();
	result.Vehicle = new Vehicle();
	result.Insurer = new Person();
	result.Insurer.Name = json.Insurer.FirstName +' '+ json.Insurer.LastName;	
	result.Vehicle.Model = json.Vehicle.Model;
	result.Vehicle.Mark = json.Vehicle.Mark;	
	result.EffectiveDate = json.DateBegin;
	result.ExpirationDate = json.DateEnd;	
	return result;
};

function MapperTwo(context)
{
	var json=JSON.parse(context);
	var result = new BasePolicy();
	result.Vehicle = new Vehicle();
	result.Insurer = new Person();
	result.Insurer.Name = json.InsurerFirstName +' '+ json.InsurerLastName;	
	result.Vehicle.Model = json.Vehicle.Model;
	result.Vehicle.Mark = json.Vehicle.Mark;	
	result.EffectiveDate = json.DateBegin;
	result.ExpirationDate = json.DateEnd;	
	return result;
};

function MapperThree(context)
{
	var json=JSON.parse(context);
	var result = new BasePolicy();
	result.Vehicle = new Vehicle();
	result.Insurer = new Person();
	result.Insurer.Name = json.Insurer.Person.InsurerFirstName +' '+ json.Insurer.Person.InsurerLastName;	
	result.Vehicle.Model = json.VehicleModel;
	result.Vehicle.Mark = json.VehicleMark;	
	result.EffectiveDate = json.DateBegin;
	result.ExpirationDate = json.DateEnd;	
	return result;
};
