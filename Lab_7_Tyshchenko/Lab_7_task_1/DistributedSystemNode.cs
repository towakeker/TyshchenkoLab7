using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lab_7_task_1
{
    public class DistributedSystemNode
    {
        private readonly string nodeId;
        private bool isActive;
        private readonly List<DistributedSystemNode> connectedNodes;

        public event EventHandler<string> MessageReceived;
        public event EventHandler<bool> StatusChanged;

        public DistributedSystemNode(string nodeId)
        {
            this.nodeId = nodeId;
            isActive = true;
            connectedNodes = new List<DistributedSystemNode>();
        }

        public async Task SendAsync(string message, DistributedSystemNode destinationNode)
        {
            await Task.Delay(100);
            destinationNode.Receive(message, this);
        }

        public void Receive(string message, DistributedSystemNode senderNode)
        {
            Console.WriteLine($"Node {nodeId} received message '{message}' from Node {senderNode.nodeId}");
            OnMessageReceived(message);
        }

        public async Task StartAsync()
        {
            while (isActive)
            {
                Console.WriteLine($"Node {nodeId} is active");
                await Task.Delay(1000);

                foreach (var connectedNode in connectedNodes)
                {
                    await SendAsync($"Status update from Node {nodeId}", connectedNode);
                }
            }
        }

        public void Stop()
        {
            Console.WriteLine($"Node {nodeId} is stopping");
            isActive = false;
            OnStatusChanged(false);
        }

        protected virtual void OnMessageReceived(string message)
        {
            MessageReceived?.Invoke(this, message);
        }

        protected virtual void OnStatusChanged(bool newStatus)
        {
            StatusChanged?.Invoke(this, newStatus);
        }

        public void ConnectToNode(DistributedSystemNode node)
        {
            connectedNodes.Add(node);
            node.StatusChanged += (sender, status) =>
            {
                Console.WriteLine(
                    $"Node {nodeId} received status update from Node {((DistributedSystemNode)sender).nodeId}. Status: {status}");
            };
        }
    }
}
