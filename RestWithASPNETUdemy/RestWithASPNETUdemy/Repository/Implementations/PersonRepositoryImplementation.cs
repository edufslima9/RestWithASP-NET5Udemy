﻿using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Implementations
{
    public class PersonRepositoryImplementation : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepositoryImplementation(PostgreSQLContext context) : base (context) { }

        public Person Disable(long id)
        {
            if (!_context.Persons.Any(p => p.Id.Equals(id))) return null;

            var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName))
                return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            else if (String.IsNullOrWhiteSpace(firstName) && !String.IsNullOrWhiteSpace(lastName))
                return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
            else if (!String.IsNullOrWhiteSpace(firstName) && String.IsNullOrWhiteSpace(lastName))
                return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();

            return null;
        }
    }
}
