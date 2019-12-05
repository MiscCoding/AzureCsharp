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

namespace WinFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.cmbBxRegionData.Items.Clear();
            foreach(var item in Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region.Values)
            {
                this.cmbBxRegionData.Items.Add(item);
            }
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
                message = String.Format("RegionName : {0}, ID : {1} was created! ResourceGroup state is {2} ", resourceGroup.RegionName, resourceGroup.Id, resourceGroup.ProvisioningState);
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
            


        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var credentials = SdkContext.AzureCredentialsFactory.FromFile("servicePrincipleInformation.json");
                var azure = Azure
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
    }
}
