using shpr2;

// Chain of responsibility

var userManager = new UserManager();
userManager.Authorisation("12345678", "12345Aa!eeee");
userManager.Registration("12345678", "12345Aa!eeee");
userManager.Authorisation("12345678", "12345Aa!eeee");
userManager.Logout();
userManager.Logout();
userManager.Authorisation("12345678", "12345Aa!eeee");
userManager.Authorisation("12345678", "12345Aa!eeee");