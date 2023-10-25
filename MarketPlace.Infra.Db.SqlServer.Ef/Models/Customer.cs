using System;
using System.Collections.Generic;

namespace MarketPlace.Infra.Db.SqlServer.Ef.Models;

public partial class Customer
{
    public int Id { get; set; }

    public int AddressId { get; set; }

    public virtual ICollection<ActionProposal> ActionProposals { get; set; } = new List<ActionProposal>();

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
