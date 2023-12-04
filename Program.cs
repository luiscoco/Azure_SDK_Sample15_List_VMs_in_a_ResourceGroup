using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute;
using Azure;

// 1. Azure Authorization
ArmClient armClient = new ArmClient(new DefaultAzureCredential());
SubscriptionResource subscription = await armClient.GetDefaultSubscriptionAsync();

// 2. Get the ResourceGroup
string rgName = "myRG";
ResourceGroupResource resourceGroup = await subscription.GetResourceGroups().GetAsync(rgName);

// 3. Get the virtual machine collection from the resource group
VirtualMachineCollection vmCollection = resourceGroup.GetVirtualMachines();

// 4. List of the virtual machines
AsyncPageable<VirtualMachineResource> response = vmCollection.GetAllAsync();
await foreach (VirtualMachineResource vm in response)
{
    Console.WriteLine(vm.Data.Name);
}