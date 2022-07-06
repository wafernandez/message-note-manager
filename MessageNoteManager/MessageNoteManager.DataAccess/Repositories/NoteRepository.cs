using MessageNoteManager.DataAccess.Interface;
using MessageNoteManager.Domain;
using MessageNoteManager.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageNoteManager.DataAccess
{
    public class NoteRepository : INoteRepository
    {
        private readonly DbSet<Note> _notes;
        private readonly DbContext _context;

        public NoteRepository(DbContext context)
        {
            _notes = context.Set<Note>();
            _context = context;
        }
        public Note Add(Note newNote)
        {
            _notes.Add(newNote);
            _context.SaveChanges();

            return newNote;
        }

        public Note Update(Note toUpdate)
        {
            _notes.Update(toUpdate);
            _context.SaveChanges();

            return toUpdate;
        }

        public Note GetById(int noteId)
        {
            Note note = _notes
                        .Include(n => n.Owner)
                        .SingleOrDefault(n => n.Id == noteId);
            return note;
        }

        public List<Note> GetByUserId(string userId)
        {
            try
            {
                return TryGetByUserId(userId);
            }
            catch (SqlException)
            {
                throw new DataUnavailableException();
            }
            catch (DbException)
            {
                throw new DataUnavailableException();
            }
            catch (EntityException)
            {
                throw new DataUnavailableException();
            }
        }

        public List<Note> GetAll()
        {
            try
            {
                return TryGetAll();
            }
            catch (SqlException)
            {
                throw new DataUnavailableException();
            }
            catch (DbException)
            {
                throw new DataUnavailableException();
            }
            catch (EntityException)
            {
                throw new DataUnavailableException();
            }
        }

        private List<Note> TryGetAll()
        {
            List<Note> allMessages = _notes
                                    .Include(n => n.Owner)
                                    .ToList();
            return allMessages;
        }

        private List<Note> TryGetByUserId(string userId)
        {
            List<Note> userMessages = _notes
                                    .Include(n => n.Owner)
                                    .Where(n => n.Owner.UserId == userId)
                                    .ToList();
            return userMessages;
        }
    }
}
