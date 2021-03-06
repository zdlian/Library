using Library.Domain.Core;
using Library.Domain.Core.DataAccessor;
using Library.Domain.Core.Messaging;
using Library.Service.Inventory.Domain.Commands;
using Library.Service.Inventory.Domain.DataAccessors;
using System;

namespace Library.Service.Inventory.Domain.CommandHandlers
{
    public class InStoreBookInventoryCommandHandler : BaseInventoryCommandHandler<InStoreBookInventoryCommand>
    {
        public InStoreBookInventoryCommandHandler(IDomainRepository domainRepository, IInventoryReportDataAccessor dataAccesor, ICommandTracker tracker, ILogger logger) : base(domainRepository, dataAccesor, tracker, logger)
        {
        }

        public override void ExecuteCore(InStoreBookInventoryCommand command)
        {
            try
            {
                var bookInventory = _domainRepository.GetById<BookInventory>(command.BookInventoryId);
                bookInventory.InStore(command.Notes, command.InStoreDate);
                _domainRepository.Save(bookInventory, bookInventory.Version, command.CommandUniqueId);

                command.Result(InStoreBookInventoryCommand.Code_INSTORE_COMPLETED);
            }
            catch (Exception ex)
            {
                command.Result(InStoreBookInventoryCommand.Code_SERVER_ERROR, ex.ToString());
            }
        }
    }
}