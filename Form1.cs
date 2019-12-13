using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Network.Fluent;
using System.Reflection;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.ServiceBus;
using System.IO;

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.cmbBxRegionData.Items.Clear();
            this.cmbBxPublisher.Items.Clear();
            this.cmbBxOffer.Items.Clear();
            this.cmbBxSku.Items.Clear();

            BindingSource bsPublisher = new BindingSource();
            bsPublisher.DataSource = new List<String> { "MicrosoftWindowsServer", "MicrosoftDynamicsNAV", "MicrosoftSharePoint", "MicrosoftSQLServer", "MicrosoftRServer" };
            this.cmbBxPublisher.DataSource = bsPublisher;


            BindingSource bsOffer = new BindingSource();
            bsOffer.DataSource = new List<String> { "WindowsServer", "DynamicsNAV", "MicrosoftSharePointServer", "SQL2019-WS2016", "RServer-WS2016"};
            this.cmbBxOffer.DataSource = bsOffer;

            BindingSource bsSKU = new BindingSource();
            bsSKU.DataSource = new List<String> { "2019-Datacenter", "2019-Datacenter-Core", "2019-Datacenter-with-Containers", "2016-Datacenter", "2016-Datacenter-Server-Core", "2016-Datacenter-with-Containers", "2012-R2-Datacenter", "2012-Datacenter", "2017", "2019", "Enterprise"};
            this.cmbBxSku.DataSource = bsSKU;


            foreach (var item in Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Values)
            {
                this.cmbBxRegionData.Items.Add(item);
            }

            //Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineSizeTypes myType = new Microsoft.Azure.Management.Compute.Fluent.Models.VirtualMachineSizeTypes();
            //var bindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic |
            //                    System.Reflection.BindingFlags.Public;
            //List<object> VMSizeTypeslistValues = myType.GetType().GetFields(bindingFlags).Select(field => field.GetValue(myType)).Where(value => value != null).ToList();
            //FieldInfo[] fields = typeof(myType).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            
            //foreach (var vmSizeType in fields)
            //{
            //    this.cmbBxVMSizeType.Items.Add(vmSizeType);
            //}
        }


        public void runSample(IAzure azure)
        {
            var region = this.cmbBxRegionData.SelectedItem as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            //var region = Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.AsiaSouthEast;
            var windowsVmName = this.txtBxVMName.Text;
            var resourceGroupName = this.txtBxResourceGroupName.Text;
            //var linuxVmName = Utilities.CreateRandomName("lVM");
            //var rgName = Utilities.CreateRandomName("rgCOMV");
            var userName = this.txtBxVMUserName.Text;
            var password = this.txtBxVMPasswd.Text;
            IResourceGroup resourceGroup = null;
            string message = string.Empty;
            message = "Resource group is being created";
            Utilities.Log(message);
            this.lblCurrentStatus.Text = message;
            try
            {
                resourceGroup = azure.ResourceGroups.Define(resourceGroupName)
                                .WithRegion(region)
                                .Create();
                message = String.Format("Resource Group: {0}, RegionName : {1}, ID : {2} was created! ResourceGroup state is {3} ", resourceGroupName, resourceGroup.RegionName, resourceGroup.Id, resourceGroup.ProvisioningState);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
                
            }
            catch(Exception ex)
            {
                message = ex.ToString();
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }

            message = "Creating public IP address in dynamic manner";
            this.lblCurrentStatus.Text = message;

            Utilities.Log(message);

            IPublicIPAddress publicIpAddressForVM = null;

            string IPResourceName = this.txtBxPublicIPName.Text;
            try
            {
                publicIpAddressForVM = azure.PublicIPAddresses.Define(IPResourceName)
                                    .WithRegion(region)
                                    .WithExistingResourceGroup(resourceGroupName)
                                    .WithDynamicIP()
                                    .Create();
                message = String.Format("Public IP address {0} has been made, Regional name :  {1}, FQDN: {2} ", publicIpAddressForVM.IPAddress, publicIpAddressForVM.RegionName, publicIpAddressForVM.Fqdn);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }
            catch(Exception ex)
            {
                message = ex.ToString();
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }

            message = "Creating virtual network....";
            this.lblCurrentStatus.Text = message;
            Utilities.Log(message);
            INetwork networkCreated = null;

            string virtualNetworkName = this.txtBxPublicIPName.Text;
            string addressSpace = this.txtBxAddressSpace.Text;
            string subnetName = this.txtBxSubnetName.Text;
            string subnetValue = this.txtBxSubnetValue.Text;
            try
            {
                networkCreated = azure.Networks.Define(virtualNetworkName)
                            .WithRegion(region)
                        .WithExistingResourceGroup(resourceGroupName)
                            .WithAddressSpace(addressSpace)
                        .WithSubnet(subnetName, subnetValue)
                        .Create();

                message = String.Format("Virtual network created {0} in region {1}, address space: {2},  subnets {3} ", virtualNetworkName, networkCreated.RegionName, networkCreated.AddressSpaces, networkCreated.Subnets);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }
            catch(Exception ex)
            {
                message = ex.ToString();
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }

            message = "Creating network interface....";
            this.lblCurrentStatus.Text = message;
            Utilities.Log(message);
            INetworkInterface networkInterfaceCreated = null;

            string NICInterfaceDefinition = this.txtBxNICDefinition.Text;
            
            try
            {
                networkInterfaceCreated = azure.NetworkInterfaces.Define(NICInterfaceDefinition)
                                        .WithRegion(region)
                                        .WithExistingResourceGroup(resourceGroup)
                                        .WithExistingPrimaryNetwork(networkCreated)
                                        .WithSubnet(subnetName)
                                        .WithPrimaryPrivateIPAddressDynamic()
                                        .WithExistingPrimaryPublicIPAddress(publicIpAddressForVM)
                                        .Create();

                message = String.Format("network interface card created {0} in region {1}, address space: {2},  subnets {3} ", NICInterfaceDefinition, networkCreated.RegionName, networkCreated.AddressSpaces, networkCreated.Subnets);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }

            message = "Creating virtual machine....";
            this.lblCurrentStatus.Text = message;
            Utilities.Log(message);
            IVirtualMachine virtualMachineCreated = null;

            string strVMNameToCreate = this.txtBxVMName.Text;
            string strVMUserName = this.txtBxVMUserName.Text;
            string strVMPassword = this.txtBxVMPasswd.Text;
            string imagePublisher = this.cmbBxPublisher.SelectedItem as string;
            string imageOffer = this.cmbBxOffer.SelectedItem as string;
            string imageSKU = this.cmbBxSku.SelectedItem as string;
            try
            {
                virtualMachineCreated = azure.VirtualMachines.Define(strVMNameToCreate)
                                        .WithRegion(region)
                                        .WithExistingResourceGroup(resourceGroupName)
                                        .WithExistingPrimaryNetworkInterface(networkInterfaceCreated)
                                        .WithLatestWindowsImage(imagePublisher, imageOffer, imageSKU)
                                        .WithAdminUsername(strVMUserName)
                                        .WithAdminPassword(strVMPassword)
                                        .WithComputerName(strVMNameToCreate)
                                        .WithSize(VirtualMachineSizeTypes.StandardB2s)
                                        .Create();

                message = String.Format("network interface card created {0} in region {1}, address space: {2},  subnets {3} ", NICInterfaceDefinition, networkCreated.RegionName, networkCreated.AddressSpaces, networkCreated.Subnets);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }
            catch (Exception ex)
            {
                message = ex.ToString();
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }


            message = "Creating virtual machine snapshot";
            this.lblCurrentStatus.Text = message;
            Utilities.Log(message);
            
            string snapshotName = string.Empty;
            snapshotName = this.txtBxSnapshotName.Text;

            try
            {
                IDisk osDisk = azure.Disks.GetById(virtualMachineCreated.OSDiskId);

                message = String.Format("Virtual machine snapshot of disk : {0}, name : {1} ", osDisk.Id, osDisk.Name);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);


                ISnapshot osSnapshot = azure.Snapshots.Define(snapshotName + "-" + Guid.NewGuid())
                .WithRegion(region)
                .WithExistingResourceGroup(resourceGroup)
                .WithDataFromDisk(osDisk)
                .Create();

                message = String.Format("Created Virtual machine snapshot of disk : {0}, name : {1}, snapshot id : {2}, snapshotName {3}", osDisk.Id, osDisk.Name, osSnapshot.Id, osSnapshot.Name);
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }
            catch(Exception ex)
            {
                message = ex.ToString();
                this.lblCurrentStatus.Text = message;
                Utilities.Log(message);
            }
            



        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromFile("servicePrincipleInformation.json");
                var azure = Microsoft.Azure.Management.Fluent.Azure
                        .Configure()
                        .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                        .Authenticate(credentials)
                        .WithDefaultSubscription();

                Utilities.Log("Selected subscription: " + azure.SubscriptionId);
                this.lblCurrentStatus.Text = "Selected subscription: " + azure.SubscriptionId;

                runSample(azure);
            }
            catch(Exception ex)
            {
                this.lblCurrentStatus.Text = ex.ToString();
                Utilities.Log(ex.ToString());
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var region = this.cmbBxRegionData.SelectedItem as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            MessageBox.Show(region.ToString());
        }

        private void btnBlobInfoGet_Click(object sender, EventArgs e)
        {
            BasicStorageBlockBlobOperationsAsync();
        }

        private async Task BasicStorageBlockBlobOperationsAsync()
        {
            //const string ImageToUpload = "HelloWorld.png";
            string containerPrefix = this.txtBxBlobContainerName.Text;
            string containerName = containerPrefix + Guid.NewGuid();

            // Retrieve storage account information from connection string
            CloudStorageAccount storageAccount = Common.CreateStorageAccountFromConnectionString();

            // Create a blob client for interacting with the blob service.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Create a container for organizing blobs within the storage account.
            this.lblCurrentStatus.Text = ("1. Creating Container");
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            try
            {
                // The call below will fail if the sample is configured to use the storage emulator in the connection string, but 
                // the emulator is not running.
                // Change the retry policy for this call so that if it fails, it fails quickly.
                BlobRequestOptions requestOptions = new BlobRequestOptions() { RetryPolicy = new Microsoft.Azure.Storage.RetryPolicies.NoRetry() };
                await container.CreateIfNotExistsAsync(requestOptions, null);
            }
            catch (StorageException)
            {
                this.lblCurrentStatus.Text = ("If you are running with the default connection string, please make sure you have started the storage emulator. Press the Windows key and type Azure Storage to select and run it from the list of applications - then restart the sample.");
                Console.ReadLine();
                throw;
            }

            // To view the uploaded blob in a browser, you have two options. The first option is to use a Shared Access Signature (SAS) token to delegate 
            // access to the resource. See the documentation links at the top for more information on SAS. The second approach is to set permissions 
            // to allow public access to blobs in this container. Uncomment the line below to use this approach. Then you can view the image 
            // using: https://[InsertYourStorageAccountNameHere].blob.core.windows.net/democontainer/HelloWorld.png
            // await container.SetPermissionsAsync(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            ////Upload a BlockBlob to the newly created container
            //Console.WriteLine("2. Uploading BlockBlob");
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference(ImageToUpload);

            ////Set the blob's content type so that the browser knows to treat it as an image.
            //blockBlob.Properties.ContentType = "image/png";
            //await blockBlob.UploadFromFileAsync(ImageToUpload);

            // List all the blobs in the container.
            /// Note that the ListBlobs method is called synchronously, for the purposes of the sample. However, in a real-world
            /// application using the async/await pattern, best practices recommend using asynchronous methods consistently.
            this.lblCurrentStatus.Text = ("3. List Blobs in Container");
            string blobURI = string.Empty;
            string getType = string.Empty;
            foreach (IListBlobItem blob in container.ListBlobs())
            {
                // Blob type will be CloudBlockBlob, CloudPageBlob or CloudBlobDirectory
                // Use blob.GetType() and cast to appropriate type to gain access to properties specific to each type
                this.lblCurrentStatus.Text = (String.Format("- {0} (type: {1})", blob.Uri.ToString(), blob.GetType().ToString()));

            }
            

            // Download a blob to your file system
            //Console.WriteLine("4. Download Blob from {0}", blockBlob.Uri.AbsoluteUri);
            //await blockBlob.DownloadToFileAsync(string.Format("./CopyOf{0}", ImageToUpload), FileMode.Create);

            //// Create a read-only snapshot of the blob
            //Console.WriteLine("5. Create a read-only snapshot of the blob");
            //CloudBlockBlob blockBlobSnapshot = await blockBlob.CreateSnapshotAsync(null, null, null, null);

            // Clean up after the demo. This line is not strictly necessary as the container is deleted in the next call.
            // It is included for the purposes of the example. 
            //Console.WriteLine("6. Delete block blob and all of its snapshots");
            //await blockBlob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, null, null, null);

            //// Note that deleting the container also deletes any blobs in the container, and their snapshots.
            //// In the case of the sample, we delete the blob and its snapshots, and then the container,
            //// to show how to delete each kind of resource.
            //Console.WriteLine("7. Delete Container");
            //await container.DeleteIfExistsAsync();
        }
    }
}
